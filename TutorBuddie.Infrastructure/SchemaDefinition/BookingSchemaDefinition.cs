using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Enums;
using TutorBuddie.Infrastructure.Data;

namespace TutorBuddie.Infrastructure.SchemaDefinition;

internal class BookingSchemaDefinition : IEntityTypeConfiguration<Booking>
{
	public void Configure(EntityTypeBuilder<Booking> builder)
	{
		builder.ToTable("Bookings", BuddyContext.DefaultSchema);
		builder.HasKey(x => x.Id);

		builder.Property(p => p.TutorId)
			.IsRequired();

		builder.Property(b => b.CourseId)
			.IsRequired();

		builder.Property(b => b.Status)
			.IsRequired()
			.HasConversion(
				s => s.ToString(),
				s => Enum.Parse<Status>(s)
			);

		builder.HasOne(b => b.User)
			.WithMany() // Adjust if User has a collection of Bookings
			.HasForeignKey(b => b.UserId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(b => b.TutorCourse)
			.WithMany() // Adjust if Tutor has a collection of Bookings
			.HasForeignKey(b => new { b.TutorId ,b.CourseId})
			.OnDelete(DeleteBehavior.Restrict);
	}
}