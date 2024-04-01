using FluentResults;
using SimplifyPos.Application.Abstractions;
using SimplifyPos.Application.Extensions;

namespace SimplifyPos.Application.Products.Create;

public class AddProductCommandHandler : ICommandHandler<AddProductCommand, Result<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    
    public AddProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<ProductDto>> Handle(AddProductCommand command, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid().ToString("N");
        var entity = command.ToEntity(id);

        await _productRepository.CreateProductAsync(entity);

        return Result.Ok(entity.ToDto());
    }
}