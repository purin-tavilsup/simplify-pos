using FluentResults;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Logging;
using SimplifyPos.Application.Abstractions;
using SimplifyPos.Application.Extensions;

namespace SimplifyPos.Application.CatalogProducts.Add;

public class AddCatalogProductCommandHandler : ICommandHandler<AddCatalogProductCommand, Result<CatalogProductDto>>
{
    private readonly ICatalogProductRepository _catalogProductRepository;
    private readonly ILogger<AddCatalogProductCommandHandler> _logger;
    
    public AddCatalogProductCommandHandler(ICatalogProductRepository catalogProductRepository, 
                                           ILogger<AddCatalogProductCommandHandler> logger)
    {
        _catalogProductRepository = catalogProductRepository;
        _logger = logger;
    }

    public async Task<Result<CatalogProductDto>> Handle(AddCatalogProductCommand command, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid().ToString("N");
        var entity = command.ToEntity(id);
        
        try
        {
            var result = await _catalogProductRepository.AddCatalogProduct(entity);
        
            return Result.Ok(result.ToDto());
        }
        catch (CosmosException ex)
        {
            _logger.LogWarning("{Message}", ex.Message);
            const string message = "An error occurred while adding a catalog product";
            var error = new Error(message);
            
            return Result.Fail<CatalogProductDto>(error);
        }
    }
}