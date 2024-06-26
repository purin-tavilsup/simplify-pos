﻿using Dapper;
using SimplifyPos.Application.Abstractions;
using SimplifyPos.Domain.Entities.Inventory;

namespace SimplifyPos.Infrastructure.Data.Sqlite;

public class ProductRepository : IProductRepository
{
	private readonly AppDbContext _context;

	public ProductRepository(AppDbContext context)
	{
		_context = context;
	}

	public async Task CreateProductAsync(InventoryProduct inventoryProduct)
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
			inventoryProduct.Id,
			inventoryProduct.Barcode,
			inventoryProduct.Description,
			inventoryProduct.Brand,
			inventoryProduct.UnitPrice,
			inventoryProduct.QuantityInStock
		};

		await connection.ExecuteAsync(sqlCommand, sqlParameters);
	}

	public async Task<IEnumerable<InventoryProduct>> GetProductsAsync()
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

		var results = await connection.QueryAsync<InventoryProduct>(sqlCommand);

		return results.ToList();
	}

	public async Task<InventoryProduct?> GetProductByIdAsync(string id)
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
		                          WHERE Id = @Id
		                          """;
		
		var sqlParameters = new { Id = id };
		var result = await connection.QueryAsync<InventoryProduct>(sqlCommand, sqlParameters);

		return result.FirstOrDefault();
	}

	public Task<InventoryProduct> GetProductByBarcodeAsync(string barcode)
	{
		throw new NotImplementedException();
	}

	public Task UpdateProduct(InventoryProduct inventoryProduct)
	{
		throw new NotImplementedException();
	}

	public Task DeleteProductByIdAsync(string id)
	{
		throw new NotImplementedException();
	}
}