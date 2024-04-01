using FluentResults;
using SimplifyPos.Application.Abstractions;
using SimplifyPos.Application.Extensions;

namespace SimplifyPos.Application.Products.List;

public class ListProductsQueryHandler : IQueryHandler<ListProductsQuery, Result<IEnumerable<ProductDto>>>
{
    private readonly IProductRepository _productRepository;
    
    public ListProductsQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<Result<IEnumerable<ProductDto>>> Handle(ListProductsQuery query, CancellationToken cancellationToken)
    {
        var results = await _productRepository.GetProductsAsync();
        
        return Result.Ok(results.ToDto());
    }
}