using MediatR;

namespace SistemaComercial.Aplicacion.Abstractions.Messaging;

public interface ICommand : IRequest, IBaseCommand
{
}

public interface ICommand<TResponse> : IRequest<TResponse>, IBaseCommand
{
}

public interface IBaseCommand
{
}
