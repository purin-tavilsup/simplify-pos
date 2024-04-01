using FluentResults;
using SimplifyPos.Application.Abstractions;
using SimplifyPos.Application.Enums;
using SimplifyPos.Application.Extensions;
using SimplifyPos.Domain.Entities.Catalog;

namespace SimplifyPos.Application.CatalogProducts.Add;

public record AddCatalogProductCommand(CatalogProductCategory Category, 
                                       string Description, 
                                       string Brand) 
    : ICommand<Result<CatalogProductDto>>;

public static class AddCatalogProductCommandExtensions
{
    public static CatalogProduct ToEntity(this AddCatalogProductCommand command, string id)
    {
        var categoryId = command.Category.ToCategoryId();
        var categoryName = command.Category.ToString();
        
        return new CatalogProduct
        {
            id = id,
            categoryId = categoryId,
            categoryName = categoryName,
            description = command.Description,
            brand = command.Brand
        };
    }
}