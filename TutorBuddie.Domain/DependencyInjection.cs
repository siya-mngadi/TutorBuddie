using FluentValidation;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using TutorBuddie.Domain.Repositories;
using TutorBuddie.Domain.Services;
using TutorBuddie.Domain.Services.Implementations;

namespace TutorBuddie.Domain;

public static class DependencyInjection
{
	public static IServiceCollection AddDomain(this IServiceCollection services)
	{
		services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

		services.AddScoped<IUserService, UserService>();
		services.AddScoped<IBookingService, BookingService>();
		services.AddScoped<ICourseService, CourseService>();
		services.AddScoped<IPaymentService, PaymentService>();
		services.AddScoped<IReviewService, ReviewService>();
		services.AddScoped<ITutorService, TutorService>();
		return services;
	}
}