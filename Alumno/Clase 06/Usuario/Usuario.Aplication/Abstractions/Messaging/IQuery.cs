using MediatR;

namespace Usuario.Aplication.Abstractions.Messaging;

public interface IQuery<TResult> : IRequest<TResult>
{
}
