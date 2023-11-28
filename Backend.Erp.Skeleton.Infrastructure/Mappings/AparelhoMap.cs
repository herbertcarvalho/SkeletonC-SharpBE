using Backend.Erp.Skeleton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Erp.Skeleton.Infrastructure.Mappings
{
    internal class AparelhoMap : IEntityTypeConfiguration<Aparelho>
    {
        public void Configure(EntityTypeBuilder<Aparelho> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.SalaComAparelho).IsRequired();
            builder.Property(x => x.QuartoComAparelho).IsRequired();
            builder.Property(x => x.ExternoComAparelho).IsRequired();
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);
        }
    }
}