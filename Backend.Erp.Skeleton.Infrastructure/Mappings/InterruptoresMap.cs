using Backend.Erp.Skeleton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Erp.Skeleton.Infrastructure.Mappings
{
    internal class InterruptoresMap : IEntityTypeConfiguration<Interruptores>
    {
        public void Configure(EntityTypeBuilder<Interruptores> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.InterruptorParaAutomatizar).IsRequired();
            builder.Property(x => x.InterruptorAfastado).IsRequired();
            builder.Property(x => x.TomadasParaAutomatizar).IsRequired();
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);
        }
    }
}