﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Infrastructure.Data;

namespace TutorBuddie.Infrastructure.SchemaDefinition;

internal class ReviewSchemaDefinition : IEntityTypeConfiguration<Review>
{
	public void Configure(EntityTypeBuilder<Review> builder)
	{
		builder.ToTable("Reviews", BuddyContext.DefaultSchema);
		builder.HasKey(r => r.Id);

		// Properties
		builder.Property(r => r.UserId)
			.IsRequired();

		builder.Property(r => r.Rating)
			.IsRequired()
			.HasMaxLength(5);

		builder.Property(r => r.Comment)
			.HasMaxLength(2000);

		builder.Property(r => r.CreatedAtUtc)
			.ValueGeneratedOnAdd();

		// Relationships

		builder.HasOne(r => r.User)
			.WithMany()
			.HasForeignKey(r => r.UserId)
			.OnDelete(DeleteBehavior.Cascade);

		// Many-to-One with Tutor
		builder.HasOne(r => r.Tutor)
			.WithMany(t => t.Reviews)
			.HasForeignKey(r => r.TutorId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}