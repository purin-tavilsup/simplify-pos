using FluentResults;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using SimplifyPos.Application.Abstractions;
using SimplifyPos.Application.Extensions;

namespace SimplifyPos.Application.CatalogProducts.List;

public class ListCatalogProductsByIdQueryHandler 
    : IQueryHandler<ListCatalogProductsByIdQuery, Result<IEnumerable<CatalogProductDto>>>
{
    private readonly ICatalogProductRepository _catalogProductRepository;
    private readonly ILogger<ListCatalogProductsByIdQueryHandler> _logger;

    public ListCatalogProductsByIdQueryHandler(ICatalogProductRepository catalogProductRepository, 
                                               ILogger<ListCatalogProductsByIdQueryHandler> logger)
    {
        _catalogProductRepository = catalogProductRepository;
        _logger = logger;
    }
    
    public async Task<Result<IEnumerable<CatalogProductDto>>> Handle(ListCatalogProductsByIdQuery query, 
                                                                     CancellationToken cancellationToken)
    {
        try
        {
            var results = await _catalogProductRepository.GetProductsByCategoryIdAsync(query.CategoryId);
        
            return Result.Ok(results.ToDto());
        }
        catch (CosmosException ex)
        {
            _logger.LogWarning("{Message}", ex.Message);
            const string message = "An error occurred while getting products by `categoryId`.";
            var error = new Error(message);
            
            return Result.Fail<IEnumerable<CatalogProductDto>>(error);
        }
    }
}