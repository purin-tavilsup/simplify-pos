using FluentResults;
using SimplifyPos.Application.Abstractions;

namespace SimplifyPos.Application.CatalogProducts.List;

public record ListCatalogProductsByIdQuery(string CategoryId) : IQuery<Result<IEnumerable<CatalogProductDto>>>;