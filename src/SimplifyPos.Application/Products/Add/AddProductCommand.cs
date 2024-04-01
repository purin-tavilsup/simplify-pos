using FluentResults;
using SimplifyPos.Application.Abstractions;
using SimplifyPos.Domain.Entities.Inventory;

namespace SimplifyPos.Application.Products.Create;

public record AddProductCommand(string Barcode, 
                                   string Description, 
                                   string? Brand, 
                                   decimal UnitPrice, 
                                   int QuantityInStock) : ICommand<Result<ProductDto>>;

public static class CreateProductCommandExtensions
{
    public static InventoryProduct ToEntity(this AddProductCommand command, string id)
    {
        return new InventoryProduct
        {
            Id = id,
            Barcode = command.Barcode,
            Description = command.Description,
            Brand = command.Brand,
            UnitPrice = command.UnitPrice,
            QuantityInStock = command.QuantityInStock
        };
    }
} 