using FluentResults;
using SimplifyPos.Application.Abstractions;

namespace SimplifyPos.Application.Products.List;

public record ListProductsQuery : IQuery<Result<IEnumerable<ProductDto>>>;