using Backend.Erp.Skeleton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Erp.Skeleton.Infrastructure.Mappings
{
    internal class ImovelMap : IEntityTypeConfiguration<Imovel>
    {
        public void Configure(EntityTypeBuilder<Imovel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TipoImovel).IsRequired();
            builder.Property(x => x.Comodos).IsRequired();
            builder.Property(x => x.Andares).IsRequired();
            builder.Property(x => x.MetroQuadrado).IsRequired();
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);
        }
    }
}