using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SimplifyPos.Application.Common.Behaviors;
using System.Reflection;

namespace SimplifyPos.Application.Extensions.DependencyInjection;

public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddApplication(this IServiceCollection services)
	{
		var assembly = Assembly.GetExecutingAssembly();

		services.AddValidatorsFromAssembly(assembly);
		services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));
		services.AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));

		return services;
	}
}