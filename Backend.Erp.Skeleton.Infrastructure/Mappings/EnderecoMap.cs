using Backend.Erp.Skeleton.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Backend.Erp.Skeleton.Infrastructure.Mappings
{
    internal class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Cep).IsRequired();
            builder.Property(x => x.Numero).IsRequired();
            builder.Property(x => x.Rua).IsRequired();
            builder.Property(x => x.Bairro).IsRequired();
            builder.Property(x => x.Cidade).IsRequired();
            builder.Property(x => x.Uf).IsRequired();
            builder.Property(x => x.Complemento).IsRequired();
            builder.Property(x => x.CreatedAt);
            builder.Property(x => x.UpdatedAt);

            builder.HasIndex(x => x.ClienteId);
            builder.HasIndex(x => x.VendedorId);
            builder.HasIndex(x => x.ParceiroId);
            builder.HasIndex(x => x.InstaladorId);
        }
    }
}