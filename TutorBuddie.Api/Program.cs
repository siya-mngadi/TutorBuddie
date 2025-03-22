
using Serilog;
using System.Text.Json.Serialization;
using Asp.Versioning;
using TutorBuddie.Api.Extensions;
using TutorBuddie.Api.Middleware;
using TutorBuddie.Domain;
using TutorBuddie.Infrastructure;

namespace TutorBuddie.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
	        Log.Logger = new LoggerConfiguration()
		        .MinimumLevel.Information()
		        .CreateBootstrapLogger();

			var builder = WebApplication.CreateBuilder(args);

			// Log environment, machine, and specific details
			var environment = builder.Environment.EnvironmentName;
			var machineName = Environment.MachineName;
			var osVersion = Environment.OSVersion.VersionString;

			Console.WriteLine("Application starting: ");
			Console.WriteLine($"OS: {osVersion}");
			Console.WriteLine($"Machine: {machineName}");
			Console.WriteLine($"Environment: {environment}\n");

			// Use Kestrel as the web server
			builder.WebHost.UseKestrel();

			// Sql Server
			builder.Services.AddDatabase(builder.Configuration);
			// Add Domain
			builder.Services.AddDomain();
			// Add Infrastructure
			builder.Services.AddInfrastructure(builder.Configuration);
			builder.Services.AddControllers()
				.AddJsonOptions(options =>
				{
					options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
				});

			// Api Versioning
			builder.Services.AddApiVersioning(options =>
			{
				options.AssumeDefaultVersionWhenUnspecified = true;
				options.DefaultApiVersion = new ApiVersion(1, 0);
				options.ReportApiVersions = true;
				options.ApiVersionReader = ApiVersionReader.Combine(new UrlSegmentApiVersionReader(),
					new HeaderApiVersionReader("X-Api-Version"));
			}).AddApiExplorer(options =>
			{
				options.GroupNameFormat = "'v'VVV";
				options.SubstituteApiVersionInUrl = true;
				options.DefaultApiVersion = new ApiVersion(1, 0);
			});

			builder.Host.UseSerilog((context, config) =>
			{
				config.ReadFrom.Configuration(context.Configuration);
			});
			// Learn more about configuring Swagger/OpenAPI 
			builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.UseAuthorization();

            app.UseMiddleware<ExceptionMiddleware>();

			app.MapControllers();

            app.Run();
        }
    }
}
