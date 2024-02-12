using FluentResults;
using SimplifyPos.Application.Abstractions;

namespace SimplifyPos.Application.Products.Get;

public record GetProductByIdQuery(string Id) : IQuery<Result<ProductDto>>;