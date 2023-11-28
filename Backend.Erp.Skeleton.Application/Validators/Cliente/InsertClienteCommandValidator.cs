using Backend.Erp.Skeleton.Application.Commands.Cliente;
using FluentValidation;

namespace Backend.Contas.Application.Validators.Grupo
{
    public class InsertClienteCommandValidator : AbstractValidator<InsertClienteCommand>
    {
        public InsertClienteCommandValidator()
        {
            RuleFor(x => x.ClienteRequest)
                .NotNull();
        }
    }
}