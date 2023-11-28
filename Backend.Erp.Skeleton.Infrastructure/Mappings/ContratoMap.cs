using Backend.Erp.Skeleton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Erp.Skeleton.Infrastructure.Mappings
{
    internal class ContratoMap : IEntityTypeConfiguration<Contrato>
    {
        public void Configure(EntityTypeBuilder<Contrato> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.OrdemServico).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.Doc).IsRequired();
            builder.Property(x => x.Genero).IsRequired();
            builder.Property(x => x.QuantidadeProduto).IsRequired();
            builder.Property(x => x.FirebaseId).IsRequired();
            builder.Property(x => x.CodigoInstalacao).IsRequired();
            builder.Property(x => x.CodigoContratoParceiro).IsRequired();
            builder.Property(x => x.CodigoProdutoParceiro).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Telefone).IsRequired();
            builder.Property(x => x.CanalVenda).IsRequired();
            builder.Property(x => x.GestorVenda).IsRequired();
            builder.Property(x => x.LojaVenda).IsRequired();
            builder.Property(x => x.GrupoVenda).IsRequired();
            builder.Property(x => x.UrlContrato).IsRequired();
            builder.Property(x => x.DataCancelamento);
            builder.Property(x => x.DataNascimento);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);

            builder.HasIndex(x => x.ClienteId);
            builder.HasIndex(x => x.VendedorId);
            builder.HasIndex(x => x.ParceiroId);
            builder.HasIndex(x => x.FormaPagamentoId);

            builder
              .HasOne(c => c.Cliente)
              .WithMany()
              .OnDelete(DeleteBehavior.Restrict);

            builder
             .HasOne(c => c.Endereco)
             .WithMany()
             .OnDelete(DeleteBehavior.Restrict);

            builder
             .HasOne(c => c.Vendedor)
             .WithMany()
             .OnDelete(DeleteBehavior.Restrict);

            builder
             .HasOne(c => c.Parceiro)
             .WithMany()
             .OnDelete(DeleteBehavior.Restrict);

            builder
             .HasOne(c => c.FormaPagamento)
             .WithMany()
             .OnDelete(DeleteBehavior.Restrict);
        }
    }
}