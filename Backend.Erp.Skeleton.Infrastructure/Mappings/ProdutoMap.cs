using Backend.Erp.Skeleton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Erp.Skeleton.Infrastructure.Mappings
{
    internal class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Descricao).IsRequired();
            builder.Property(x => x.Tipo).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Quantidade).IsRequired();
            builder.Property(x => x.ValorUnitario).IsRequired();
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);
        }
    }
}