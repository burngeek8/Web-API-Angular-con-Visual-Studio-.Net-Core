using MediatR;

namespace SistemaComercial.Aplicacion.Abstractions.Messaging;

public interface IQuery<TResult> : IRequest<TResult>
{
}
