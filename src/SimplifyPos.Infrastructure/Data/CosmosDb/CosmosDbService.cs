using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;

namespace SimplifyPos.Infrastructure.Data.CosmosDb;

public class CosmosDbService
{
    private readonly CosmosClient _cosmosClient;
    
    public CosmosDbService(IConfiguration configuration)
    {
        _cosmosClient = CreateCosmosDbClient(configuration);
    }

    private static CosmosClient CreateCosmosDbClient(IConfiguration configuration)
    {
        var configurationSection = configuration.GetSection("CosmosDb");
        var accountEndpoint = configurationSection["AccountEndpoint"];
        var accountKey = configurationSection["AccountKey"];
        var connectionString = $"AccountEndpoint={accountEndpoint};AccountKey={accountKey}";
        
        return new CosmosClient(connectionString: connectionString);
    }

    public Container GetContainer(string databaseName, string containerName)
    {
        var database = _cosmosClient.GetDatabase(databaseName);
        return database.GetContainer(containerName);
    }
}