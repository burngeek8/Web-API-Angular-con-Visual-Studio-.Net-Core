using SistemaComercial.Aplicacion.Abstractions.Messaging;
using SistemaComercial.Dominio.Abstractions;
using SistemaComercial.Dominio.Cargos;

namespace SistemaComercial.Aplicacion.Cargos.CrearCargo;

internal sealed class CrearCargoCommandHandler : ICommandHandler<CrearCargoCommand, Guid>
{
    private readonly ICargoRepository _cargoRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CrearCargoCommandHandler(ICargoRepository cargoRepository, IUnitOfWork unitOfWork)
    {
        _cargoRepository = cargoRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CrearCargoCommand request, CancellationToken cancellationToken)
    {
        var nombre = request.Nombre.Trim();
        var cargoExistente = await _cargoRepository.GetByNombreAsync(nombre, cancellationToken);
        if (cargoExistente is not null)
            throw new Exception($"El cargo '{nombre}' ya existe.");

        var cargo = Cargo.Create(nombre);
        _cargoRepository.Add(cargo);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return cargo.Id;
    }
}
