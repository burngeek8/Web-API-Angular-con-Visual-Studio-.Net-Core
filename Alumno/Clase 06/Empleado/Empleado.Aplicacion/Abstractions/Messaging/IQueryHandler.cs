using MediatR;

namespace Empleado.Aplicacion.Abstractions.Messaging;

public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, TResult>
    where TQuery : IQuery<TResult>
{
}
