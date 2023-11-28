using Backend.Erp.Skeleton.Domain.Repositories;
using Backend.Erp.Skeleton.Infrastructure.DbContexts;
using Backend.Erp.Skeleton.Infrastructure.Interfaces;
using Backend.Erp.Skeleton.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace Backend.Erp.Skeleton.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddPersistenceContexts(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddTransient<IApplicationDbContext, ApplicationDbContext>();
            AddDbContext(services, configuration);
        }        

        public static void AddRepositories(this IServiceCollection services)
        {            
            services.AddTransient(typeof(IRepositoryAsync<>), typeof(RepositoryAsync<>));            
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IVendedorRepository, VendedorRepository>();
            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IOrcamentoRepository, OrcamentoRepository>();
        }

        [ExcludeFromCodeCoverage]
        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<ApplicationDbContext>(options =>
                   options.UseLazyLoadingProxies()
                   .UseInMemoryDatabase("ApplicationDb"));
            }
            else
            {
                services.AddDbContext<ApplicationDbContext>(
                     options => options.UseLazyLoadingProxies()
                        .UseSqlServer(configuration.GetConnectionString("ApplicationConnection"),
                     b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName))
                 );
            }
        }
    }
}