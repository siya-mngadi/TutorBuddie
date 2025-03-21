using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Infrastructure.Data;

namespace TutorBuddie.Infrastructure.SchemaDefinition;

public class TutorCourseSchemaDefinition : IEntityTypeConfiguration<TutorCourse>
{
	public void Configure(EntityTypeBuilder<TutorCourse> builder)
	{
		builder.ToTable("TutorCourses", BuddyContext.DefaultSchema);

		builder.HasKey(x => new {x.CourseId, x.TutorId});

		builder.HasOne(x => x.Course)
			.WithMany(x => x.TutorCourses)
			.HasForeignKey(f => f.CourseId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasOne(x => x.Tutor)
			.WithMany(x => x.Courses)
			.HasForeignKey(f => f.TutorId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}