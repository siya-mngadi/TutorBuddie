using System.Net;

namespace TutorBuddie.Api.Middleware;

public class ExceptionMiddleware
{
	private readonly RequestDelegate next;
	private readonly ILogger<ExceptionMiddleware> logger;
	public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
	{
		this.next = next;
		this.logger = logger;
	}
	public async Task InvokeAsync(HttpContext context)
	{
		try
		{
			logger.LogInformation(
				"Incoming request: {Method} {Path}{QueryString}",
				context.Request.Method,
				context.Request.Path.Value,
				context.Request.QueryString.Value
			);

			await next(context);
		}
		catch (Exception ex)
		{
			logger.LogError(ex, ex.Message);
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
			context.Response.StatusCode = StatusCodes.Status500InternalServerError;
			await context.Response.WriteAsync("Internal server error");
		}
	}
}