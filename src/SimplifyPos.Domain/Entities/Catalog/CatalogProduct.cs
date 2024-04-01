// ReSharper disable InconsistentNaming
// Class properties need to be camel casing
// because there is an issue with CosmosDb SDK serialization

namespace SimplifyPos.Domain.Entities.Catalog;

public class CatalogProduct
{
    public string id { get; set; } = string.Empty;
    public string categoryId { get; set; } = string.Empty;
    public string categoryName { get; set; } = string.Empty;
    public string description { get; set; } = string.Empty;
    public string brand { get; set; } = string.Empty;
}