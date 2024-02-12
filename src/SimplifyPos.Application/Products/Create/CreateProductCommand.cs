using FluentResults;
using SimplifyPos.Application.Abstractions;
using SimplifyPos.Domain.Entities;

namespace SimplifyPos.Application.Products.Create;

public record CreateProductCommand(
    string Barcode, 
    string Description, 
    string? Brand, 
    decimal UnitPrice, 
    int QuantityInStock) : ICommand<Result<ProductDto>>;

public static class CreateProductCommandExtensions
{
    public static Product ToEntity(this CreateProductCommand command, string id)
    {
        return new Product
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