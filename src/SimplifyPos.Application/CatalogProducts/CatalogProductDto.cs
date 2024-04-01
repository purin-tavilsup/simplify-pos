namespace SimplifyPos.Application.CatalogProducts;

public record CatalogProductDto(
    string Id, 
    string CategoryId, 
    string CategoryName, 
    string Description, 
    string Brand);