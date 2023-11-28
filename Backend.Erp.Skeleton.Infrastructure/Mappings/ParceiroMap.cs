using Backend.Erp.Skeleton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Erp.Skeleton.Infrastructure.Mappings
{
    internal class ParceiroMap : IEntityTypeConfiguration<Parceiro>
    {
        public void Configure(EntityTypeBuilder<Parceiro> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome);
            builder.Property(x => x.Doc);
            builder.Property(x => x.TipoCliente);
            builder.Property(x => x.Status);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);

            builder
              .HasOne(c => c.Endereco)
              .WithMany()
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}