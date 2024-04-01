using SimplifyPos.Application.Products;
using SimplifyPos.Domain.Entities.Inventory;

namespace SimplifyPos.Application.Extensions;

public static class ProductExtensions
{
    public static ProductDto ToDto(this InventoryProduct entity)
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
    
    public static IEnumerable<ProductDto> ToDto(this IEnumerable<InventoryProduct> entities)
    {
        return entities.Select(x => x.ToDto());
    }
}