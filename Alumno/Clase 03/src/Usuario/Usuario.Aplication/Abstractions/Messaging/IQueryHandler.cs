using MediatR;

namespace Usuario.Aplication.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}
