namespace SimplifyPos.Domain.Entities.Catalog;

public class Product
{
    public string Id { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Brand { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }
}