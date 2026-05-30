using MediatR;

namespace Empleado.Aplicacion.Abstractions.Messaging;

public interface IQuery<TResult> : IRequest<TResult>
{
}
