using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Repositories;
using TutorBuddie.Infrastructure.SchemaDefinition;

namespace TutorBuddie.Infrastructure.Data;

public class BuddyContext : IdentityDbContext<User>, IUnitOfWork
{
	public const string DefaultSchema = "dbo";

	public BuddyContext(DbContextOptions<BuddyContext> options)
		: base(options)
	{

	}

	public DbSet<Tutor> Tutors { get; set; }
	public DbSet<Payment> Payments { get; set; }
	public DbSet<Booking> Bookings { get; set; }
	public DbSet<Course> Courses { get; set; }
	public DbSet<Review> Reviews { get; set; }
	public DbSet<TutorCourse> TutorCourses { get; set; }

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfiguration(new CourseSchemaDefinition());
		modelBuilder.ApplyConfiguration(new TutorSchemaDefinition());
		modelBuilder.ApplyConfiguration(new BookingSchemaDefinition());
		modelBuilder.ApplyConfiguration(new ReviewSchemaDefinition());
		modelBuilder.ApplyConfiguration(new PaymentSchemaDefinition());
		modelBuilder.ApplyConfiguration(new TutorCourseSchemaDefinition());
		base.OnModelCreating(modelBuilder);
	}

	public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default)
	{
		await SaveChangesAsync(cancellationToken);
		return true;
	}
}