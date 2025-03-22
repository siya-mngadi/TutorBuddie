using Microsoft.EntityFrameworkCore;
using TutorBuddie.Infrastructure.Data;

namespace TutorBuddie.Api.Extensions;

public static class DatabaseExtensions
{
	public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<BuddyContext>(options =>
		{
			options.UseSqlServer(configuration.GetConnectionString("Buddy"), serverOptions =>
			{
				serverOptions.MigrationsAssembly(typeof(Program).Assembly.FullName);
			});
		});
		return services;
	}
}