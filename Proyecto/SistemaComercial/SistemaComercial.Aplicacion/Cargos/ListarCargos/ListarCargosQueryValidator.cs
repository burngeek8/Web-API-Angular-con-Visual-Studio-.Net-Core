using FluentValidation;

namespace SistemaComercial.Aplicacion.Cargos.ListarCargos;

public sealed class ListarCargosQueryValidator : AbstractValidator<ListarCargosQuery>
{
    public ListarCargosQueryValidator()
    {
        RuleFor(x => x.Q)
            .MaximumLength(100)
            .WithMessage("El filtro q no puede superar los 100 caracteres.");
    }
}
