using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Infrastructure.Data;

namespace TutorBuddie.Infrastructure.SchemaDefinition;

internal class CourseSchemaDefinition : IEntityTypeConfiguration<Course>
{
	public void Configure(EntityTypeBuilder<Course> builder)
	{
		builder.ToTable("Courses", BuddyContext.DefaultSchema);
		builder.HasKey(c => c.Id);

		// Properties
		builder.Property(c => c.Name)
			.IsRequired()
			.HasMaxLength(255);

		builder.Property(c => c.Description)
			.HasMaxLength(2000);

		// Many-to-Many Relationship with Tutors via TutorCourse
		builder.HasMany(c => c.TutorCourses)
			.WithOne(tc => tc.Course)
			.HasForeignKey(tc => tc.CourseId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}