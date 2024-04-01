using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using SimplifyPos.Application.Abstractions;
using SimplifyPos.Domain.Entities.Catalog;

namespace SimplifyPos.Infrastructure.Data.CosmosDb;

public class CatalogProductRepository : ICatalogProductRepository
{
    private readonly CosmosDbService _cosmosDbService;
    private readonly string _databaseName;
    private readonly string _containerName;
    
    public CatalogProductRepository(CosmosDbService cosmosDbService, IConfiguration configuration)
    {
        var configurationSection = configuration.GetSection("CosmosDb");
        _databaseName = configurationSection["DatabaseName"] ?? string.Empty;
        _containerName = configurationSection["ContainerName"] ?? string.Empty;
        _cosmosDbService = cosmosDbService;
    }

    private Container GetContainer()
    {
        return _cosmosDbService.GetContainer(_databaseName, _containerName);
    }

    public async Task<IEnumerable<CatalogProduct>> GetProductsByCategoryIdAsync(string categoryId)
    {
        var container = GetContainer();
        var results = new List<CatalogProduct>();
        const string query = """
                             SELECT
                                 p.id,
                                 p.categoryId,
                                 p.categoryName,
                                 p.description,
                                 p.brand
                             FROM catalogProduct p  
                             WHERE p.categoryId = @categoryId
                             """;
        
        var parameterizedQuery = new QueryDefinition(query).WithParameter("@categoryId", categoryId);
        using var filteredFeed = container.GetItemQueryIterator<CatalogProduct>(parameterizedQuery);
        
        while (filteredFeed.HasMoreResults)
        {
            var response = await filteredFeed.ReadNextAsync();
            results.AddRange(response.ToList());
        }

        return results;
    }

    public async Task<CatalogProduct> AddCatalogProduct(CatalogProduct entity)
    {
        var container = GetContainer();
        var partitionKey = new PartitionKey(entity.categoryId);
        var response = await container.CreateItemAsync(entity, partitionKey);
        return response.Resource;
    }
}