using Backend.Erp.Skeleton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Erp.Skeleton.Infrastructure.Mappings
{
    internal class ClienteContratoMap : IEntityTypeConfiguration<ClienteContrato>
    {
        public void Configure(EntityTypeBuilder<ClienteContrato> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);

            builder.HasIndex(x => x.ClienteId);
            builder.HasIndex(x => x.ContratoId);

        }
    }
}