using SimplifyPos.Domain.Entities;

namespace SimplifyPos.Application.Abstractions;

public interface IProductRepository
{
	public Task CreateProductAsync(Product product);

	public Task<IEnumerable<Product>> ListProductsAsync();

	public Task<Product> GetProductByIdAsync(string id);

	public Task<Product> GetProductByBarcodeAsync(string barcode);

	public Task UpdateProduct(Product product);

	public Task DeleteProductByIdAsync(string id);
}