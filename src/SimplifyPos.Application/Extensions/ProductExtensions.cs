using SimplifyPos.Application.Products;
using SimplifyPos.Domain.Entities.Inventory;

namespace SimplifyPos.Application.Extensions;

public static class ProductExtensions
{
    public static ProductDto ToDto(this Product entity)
    {
        return new ProductDto
        {
            Id = entity.Id,
            Barcode = entity.Barcode,
            Description = entity.Description,
            Brand = entity.Brand,
            UnitPrice = entity.UnitPrice,
            QuantityInStock = entity.QuantityInStock
        };
    }
    
    public static IEnumerable<ProductDto> ToDto(this IEnumerable<Product> entities)
    {
        return entities.Select(x => x.ToDto());
    }
}