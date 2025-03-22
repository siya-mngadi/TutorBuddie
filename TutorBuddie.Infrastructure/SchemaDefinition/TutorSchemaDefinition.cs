using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Infrastructure.Data;

namespace TutorBuddie.Infrastructure.SchemaDefinition;

internal class TutorSchemaDefinition : IEntityTypeConfiguration<Tutor>
{
	public void Configure(EntityTypeBuilder<Tutor> builder)
	{
		builder.ToTable("Tutors", BuddyContext.DefaultSchema);
		builder.HasKey(t => t.Id);

		// Properties
		builder.Property(t => t.UserId)
			.IsRequired();

		builder.Property(p => p.AmountPerHour)
			.IsRequired()
			.HasColumnType("decimal(18,2)");

		builder.Property(t => t.Description)
			.HasMaxLength(1000);

		// Relationships
		builder.HasOne(t => t.User)
			.WithOne() // One-to-One Relationship
			.HasForeignKey<Tutor>(t => t.UserId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasMany(t => t.Courses)
			.WithOne(c => c.Tutor) // One-to-Many Relationship
			.HasForeignKey(c => c.TutorId)
			.OnDelete(DeleteBehavior.Cascade);

		builder.HasMany(t => t.Reviews)
			.WithOne(r => r.Tutor) // One-to-Many Relationship
			.HasForeignKey(r => r.TutorId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}