using FluentValidation;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace TutorBuddie.Domain;

public static class DependencyInjection
{
	public static IServiceCollection AddDomain(this IServiceCollection services)
	{
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
		return services;
	}
}