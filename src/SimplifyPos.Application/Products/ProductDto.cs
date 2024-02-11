

namespace SimplifyPos.Application.Products;

public class ProductDto
{
    public string Id { get; set; } = string.Empty;

    public string Barcode { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public string Brand { get; set; } = string.Empty;

    public decimal UnitPrice { get; set; }

    public int QuantityInStock { get; set; }
}