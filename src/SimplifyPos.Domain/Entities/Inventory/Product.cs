namespace SimplifyPos.Domain.Entities.Inventory;

public class Product
{
	public string Id { get; set; } = string.Empty;

	public string Barcode { get; set; } = string.Empty;

	public string Description { get; set; } = string.Empty;

	public string? Brand { get; set; }

	public decimal UnitPrice { get; set; }

	public int QuantityInStock { get; set; }
}