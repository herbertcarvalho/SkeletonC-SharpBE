using Backend.Erp.Skeleton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Erp.Skeleton.Infrastructure.Mappings
{
    internal class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.DataNascimento).HasColumnType("timestamp");
            builder.Property(x => x.Doc).IsRequired();
            builder.Property(x => x.Genero).IsRequired();
            builder.Property(x => x.Telefone).IsRequired();
            builder.Property(x => x.UrlFoto);
            builder.Property(x => x.TipoCliente).IsRequired();
            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);

            builder.HasIndex(x => x.Status);
            builder.HasIndex(x => x.Doc);
            builder.HasIndex(x => x.Email);

            builder
              .HasOne(c => c.Endereco)
              .WithMany()
              .OnDelete(DeleteBehavior.Restrict);
        }
    }
}