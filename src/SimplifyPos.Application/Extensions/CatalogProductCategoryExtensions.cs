using SimplifyPos.Application.Enums;

namespace SimplifyPos.Application.Extensions;

public static class CatalogProductCategoryExtensions
{
    public static string ToCategoryId(this CatalogProductCategory category)
    {
        return category switch
        {
            CatalogProductCategory.Books => "370f4319d46848389cbfd94e5c6cd01f",
            CatalogProductCategory.Toys => "866d0e5c76fb4edc9ac9f5a9f815dbc8",
            CatalogProductCategory.Clothing => "f5b229e4496148c6ada3d9c498e0ed87",
            _ => throw new ArgumentOutOfRangeException(nameof(category), category, null)
        };
    }
}