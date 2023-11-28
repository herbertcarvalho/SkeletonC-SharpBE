using Backend.Erp.Skeleton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Erp.Skeleton.Infrastructure.Mappings
{
    internal class ContratoProdutoMap : IEntityTypeConfiguration<ContratoProduto>
    {
        public void Configure(EntityTypeBuilder<ContratoProduto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.MacAddress).IsRequired();
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);

            builder.HasIndex(x => x.ProdutoId);
            builder.HasIndex(x => x.ContratoId);

            //builder
            //  .HasOne(c => c.Produtos)
            //  .WithMany()
            //  .OnDelete(DeleteBehavior.Restrict);
        }
    }
}