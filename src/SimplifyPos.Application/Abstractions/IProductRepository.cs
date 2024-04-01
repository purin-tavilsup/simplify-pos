using SimplifyPos.Domain.Entities.Inventory;

namespace SimplifyPos.Application.Abstractions;

public interface IProductRepository
{
	public Task CreateProductAsync(InventoryProduct inventoryProduct);

	public Task<IEnumerable<InventoryProduct>> GetProductsAsync();

	public Task<InventoryProduct?> GetProductByIdAsync(string id);

	public Task<InventoryProduct> GetProductByBarcodeAsync(string barcode);

	public Task UpdateProduct(InventoryProduct inventoryProduct);

	public Task DeleteProductByIdAsync(string id);
}