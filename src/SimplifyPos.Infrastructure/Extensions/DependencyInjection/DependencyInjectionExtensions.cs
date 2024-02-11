using Microsoft.Extensions.DependencyInjection;
using SimplifyPos.Application.Abstractions;
using SimplifyPos.Infrastructure.Data.Sqlite;

namespace SimplifyPos.Infrastructure.Extensions.DependencyInjection;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services)
	{
		services.AddSingleton<AppDbContext>();
		services.AddScoped<IProductRepository, ProductRepository>();

		return services;
	}
}