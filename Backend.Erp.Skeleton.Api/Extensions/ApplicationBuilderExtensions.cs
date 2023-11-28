using Microsoft.AspNetCore.Builder;
using System.Diagnostics.CodeAnalysis;

namespace Backend.Erp.Skeleton.Api.Extensions
{
    [ExcludeFromCodeCoverage]
    public static class ApplicationBuilderExtensions
    {
        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("swagger/v1/swagger.json", "Backend.Erp.Skeleton.Api");
                options.RoutePrefix = "";
                options.EnableFilter();
                options.DisplayRequestDuration();
            });
        }
    }
}