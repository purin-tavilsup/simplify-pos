using FluentResults;
using SimplifyPos.Application.Abstractions;
using SimplifyPos.Application.Extensions;

namespace SimplifyPos.Application.Products.Create;

public class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, Result<ProductDto>>
{
    private readonly IProductRepository _productRepository;
    
    public CreateProductCommandHandler(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<Result<ProductDto>> Handle(CreateProductCommand command, CancellationToken cancellationToken)
    {
        var id = Guid.NewGuid().ToString("N");
        var entity = command.ToEntity(id);

        await _productRepository.CreateProductAsync(entity);

        return Result.Ok(entity.ToDto());
    }
}