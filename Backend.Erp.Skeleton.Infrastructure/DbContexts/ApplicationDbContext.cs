using Backend.Erp.Skeleton.Domain.Extensions;
using Backend.Erp.Skeleton.Infrastructure.Extensions;
using Backend.Erp.Skeleton.Infrastructure.Interfaces;
using Backend.Erp.Skeleton.Infrastructure.Mappings;
using Microsoft.EntityFrameworkCore;
using System;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Backend.Erp.Skeleton.Infrastructure.DbContexts
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public IDbConnection Connection => Database.GetDbConnection();

        public bool HasChanges => ChangeTracker.HasChanges();

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            foreach (var entry in ChangeTracker.Entries<Entity>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
            .SelectMany(t => t.GetProperties())
            .Where(p => p.ClrType == typeof(decimal) || p.ClrType == typeof(decimal?)))
            {
                property.SetColumnType("decimal(18,2)");
            }

            modelBuilder.ApplyUtcDateTimeConverter();
            modelBuilder.UseIdentityColumns();
            modelBuilder.ApplyConfiguration(new AparelhoMap());
            modelBuilder.ApplyConfiguration(new ClienteContratoMap());
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new ContratoMap());
            modelBuilder.ApplyConfiguration(new ContratoProdutoMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
            modelBuilder.ApplyConfiguration(new FormaPagamentoMap());
            modelBuilder.ApplyConfiguration(new ImovelMap());
            modelBuilder.ApplyConfiguration(new InstaladorMap());
            modelBuilder.ApplyConfiguration(new InstaladorOrdemServicoMap());
            modelBuilder.ApplyConfiguration(new InterruptoresMap());
            modelBuilder.ApplyConfiguration(new OrcamentoMap());
            modelBuilder.ApplyConfiguration(new OrdemServicoClienteMap());
            modelBuilder.ApplyConfiguration(new OrdemServicoMap());
            modelBuilder.ApplyConfiguration(new ParceiroMap());
            modelBuilder.ApplyConfiguration(new ProdutoMap());
            modelBuilder.ApplyConfiguration(new VendedorMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}