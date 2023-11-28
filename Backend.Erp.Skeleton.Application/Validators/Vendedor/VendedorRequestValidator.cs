using Backend.Erp.Skeleton.Application.DTOs.Request;
using FluentValidation;

namespace Backend.Contas.Application.Validators.Vendedor
{
    public class VendedorRequestValidator : AbstractValidator<VendedorRequest>
    {
        public VendedorRequestValidator()
        {
            RuleFor(x => x.Telefone)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Email)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Status)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.DataNascimento)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Doc)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Genero)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Nome)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.TipoCliente)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Endereco.Numero)
                .NotNull()
                .NotEmpty();

            RuleFor(x => x.Endereco.Bairro)
               .NotNull()
               .NotEmpty();

            RuleFor(x => x.Endereco.Cep)
               .NotNull()
               .NotEmpty();

            RuleFor(x => x.Endereco.Complemento)
               .NotNull()
               .NotEmpty();

            RuleFor(x => x.Endereco.Cidade)
               .NotNull()
               .NotEmpty();

            RuleFor(x => x.Endereco.Rua)
              .NotNull()
              .NotEmpty();

            RuleFor(x => x.Endereco.Uf)
              .NotNull()
              .NotEmpty();
        }
    }
}