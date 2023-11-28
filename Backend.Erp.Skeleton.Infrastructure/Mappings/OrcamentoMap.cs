using Backend.Erp.Skeleton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Erp.Skeleton.Infrastructure.Mappings
{
    internal class OrcamentoMap : IEntityTypeConfiguration<Orcamento>
    {
        public void Configure(EntityTypeBuilder<Orcamento> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.EmpresaNome).IsRequired();
            builder.Property(x => x.Cnpj).IsRequired();
            builder.Property(x => x.TipoCliente).IsRequired();
            builder.Property(x => x.DocCliente).IsRequired();
            builder.Property(x => x.NomeCliente).IsRequired();
            builder.Property(x => x.ContatoCliente).IsRequired();
            builder.Property(x => x.Vallidade);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);

            builder
              .HasOne(c => c.Interruptores)
              .WithMany()
              .OnDelete(DeleteBehavior.Cascade);

            builder
              .HasOne(c => c.Imovel)
              .WithMany()
              .OnDelete(DeleteBehavior.Cascade);

            builder
              .HasOne(c => c.Aparelho)
              .WithMany()
              .OnDelete(DeleteBehavior.Cascade);
        }
    }
}