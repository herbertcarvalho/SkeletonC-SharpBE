using Backend.Erp.Skeleton.Application.Commands.Vendedor;
using FluentValidation;

namespace Backend.Contas.Application.Validators.Vendedor
{
    public class InsertVendedorCommandValidator : AbstractValidator<InsertVendedorCommand>
    {
        public InsertVendedorCommandValidator()
        {
            RuleFor(x => x.VendedorRequest)
                .NotNull();
        }
    }
}