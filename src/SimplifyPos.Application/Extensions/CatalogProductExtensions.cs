using SimplifyPos.Application.CatalogProducts;
using SimplifyPos.Domain.Entities.Catalog;

namespace SimplifyPos.Application.Extensions;

public static class CatalogProductExtensions
{
    public static CatalogProductDto ToDto(this CatalogProduct entity)
    {
        return new CatalogProductDto
        (
            entity.id,
            entity.categoryId,
            entity.categoryName,
            entity.description,
            entity.brand
        );
    }
    
    public static IEnumerable<CatalogProductDto> ToDto(this IEnumerable<CatalogProduct> entities)
    {
        return entities.Select(x => x.ToDto());
    }
}