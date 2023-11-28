using Backend.Erp.Skeleton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Erp.Skeleton.Infrastructure.Mappings
{
    internal class InstaladorOrdemServicoMap : IEntityTypeConfiguration<InstaladorOrdemServico>
    {
        public void Configure(EntityTypeBuilder<InstaladorOrdemServico> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);

            builder.HasIndex(x => x.InstaladorId);
            builder.HasIndex(x => x.OrdemServicoId);

            //builder
            // .HasOne(c => c.OrdemServicos)
            // .WithMany()
            // .OnDelete(DeleteBehavior.Restrict);
        }
    }
}