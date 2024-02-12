using System.Net;
using FluentResults;
using SimplifyPos.Application.Abstractions;
using SimplifyPos.Application.Extensions;

namespace SimplifyPos.Application.Products.Get;

public class GetProductByIdQueryHandler : IQueryHandler<GetProductByIdQuery, Result<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    
    public GetProductByIdQueryHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }
    
    public async Task<Result<ProductDto>> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
    {
        var result = await _productRepository.GetProductByIdAsync(query.Id);

        if (result is null)
        {
            var message = $"Could not find a product with id `{query.Id}`.";
            var error = new Error(message).WithMetadata(nameof(HttpStatusCode), (int)HttpStatusCode.NotFound);
            return Result.Fail<ProductDto>(error);
        }
        
        return Result.Ok(result.ToDto());
    }
}