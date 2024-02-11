using Dapper;
using SimplifyPos.Application.Abstractions;
using SimplifyPos.Domain.Entities;

namespace SimplifyPos.Infrastructure.Data.Sqlite;

public class ProductRepository : IProductRepository
{
	private readonly AppDbContext _context;

	public ProductRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task CreateProductAsync(Product product)
	{
		using var connection = _context.CreateConnection();
		connection.Open();

		const string sqlCommand = """
								  INSERT INTO Product
								  (
								    Id,
								    Barcode,
								    Description,
								    Brand,
								    UnitPrice,
								    QuantityInStock
								  )
								  VALUES
								  (
								    @Id,
								    @Barcode,
								    @Description,
								    @Brand,
								    @UnitPrice,
								    @QuantityInStock
								  );
								  """;

		var sqlParameters = new
		{
			product.Id,
			product.Barcode,
			product.Description,
			product.Brand,
			product.UnitPrice,
			product.QuantityInStock
		};

		await connection.ExecuteAsync(sqlCommand, sqlParameters);
	}

	public async Task<IEnumerable<Product>> ListProductsAsync()
	{
		using var connection = _context.CreateConnection();
		connection.Open();

		const string sqlCommand = """
								  SELECT 
								  Id,
								  Barcode,
								  Description,
								  Brand,
								  UnitPrice,
								  QuantityInStock
								  FROM Product
								  """;

		var results = await connection.QueryAsync<Product>(sqlCommand);

		return results.ToList();
	}

	public Task<Product> GetProductByIdAsync(string id)
	{
		throw new NotImplementedException();
	}

	public Task<Product> GetProductByBarcodeAsync(string barcode)
	{
		throw new NotImplementedException();
	}

	public Task UpdateProduct(Product product)
	{
		throw new NotImplementedException();
	}

	public Task DeleteProductByIdAsync(string id)
	{
		throw new NotImplementedException();
	}
}