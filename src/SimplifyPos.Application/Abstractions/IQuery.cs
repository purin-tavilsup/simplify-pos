using MediatR;

namespace SimplifyPos.Application.Abstractions;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}