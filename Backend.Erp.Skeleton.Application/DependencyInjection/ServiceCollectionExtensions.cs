using Backend.Contas.Application.Queries;
using Backend.Erp.Skeleton.Application.Interfaces.Queries;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Backend.Erp.Skeleton.Application.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }

        public static IServiceCollection AddValidation(this IServiceCollection services)
        {
            services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly()));
            return services;
        }

        public static IServiceCollection AddQueryServices(this IServiceCollection services)
        {
            services.AddScoped<IClienteQueryService, ClienteQueryService>();
            services.AddScoped<IVendedorQueryService, VendedorQueryService>();
            services.AddScoped<IProdutoQueryService, ProdutoQueryService>();
            services.AddScoped<IOrcamentoQueryService, OrcamentoQueryService>();
            return services;
        }
    }
}