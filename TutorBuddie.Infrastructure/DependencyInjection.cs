using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Repositories;
using TutorBuddie.Infrastructure.Configuration;
using TutorBuddie.Infrastructure.Data;
using TutorBuddie.Infrastructure.Repositories;

namespace TutorBuddie.Infrastructure;

public static  class DependencyInjection
{
	public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddConfiguration(configuration);
		services.AddRepositories();
		services.AddTokenAuthentication(configuration);
		return services;
	}

	public static IServiceCollection AddConfiguration(this IServiceCollection services, IConfiguration configuration)
	{
		services.Configure<ConnectionStrings>(configuration.GetRequiredSection("ConnectionStrings"));
		return services;
	}

	public static IServiceCollection AddRepositories(this IServiceCollection services)
	{
		services.AddScoped<IUserRepository, UserRepository>();
		services.AddScoped<ITutorRepository, TutorRepository>();
		services.AddScoped<IReviewRepository, ReviewRepository>();
		services.AddScoped<ICourseRepository, CourseRepository>();
		services.AddScoped<IPaymentRepository, PaymentRepository>();
		services.AddScoped<IBookingRepository, BookingRepository>();
		return services;
	}

	public static IServiceCollection AddTokenAuthentication(this IServiceCollection services,
		IConfiguration configuration)
	{
		var settings = configuration.GetSection(nameof(AuthenticationSettings));
		var settingsTyped = settings.Get<AuthenticationSettings>();
		services.Configure<AuthenticationSettings>(settings);
		var key = Encoding.ASCII.GetBytes(settingsTyped.Secret);
		services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<BuddyContext>();
		services.AddAuthentication(x =>
		{
			x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		}).AddJwtBearer(x =>
		{
			x.TokenValidationParameters = new TokenValidationParameters
			{
				IssuerSigningKey = new SymmetricSecurityKey(key),
				ValidateIssuer = false,
				ValidateAudience = false,
			};
		});
		return services;
	}
}