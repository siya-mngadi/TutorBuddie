using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Infrastructure.Data;

namespace TutorBuddie.Infrastructure.SchemaDefinition;

internal class PaymentSchemaDefinition : IEntityTypeConfiguration<Payment>
{
	public void Configure(EntityTypeBuilder<Payment> builder)
	{
		builder.ToTable("Payments", BuddyContext.DefaultSchema);
		builder.HasKey(p => p.Id);

		// Properties
		builder.Property(p => p.Amount)
			.IsRequired()
			.HasColumnType("decimal(18,2)"); // Ensures proper decimal precision

		builder.Property(p => p.PaidAtUtc)
			.IsRequired();

		// One-to-One Relationship with Booking
		builder.HasOne(p => p.Booking)
			.WithOne()
			.HasForeignKey<Payment>(p => p.BookingId)
			.OnDelete(DeleteBehavior.Cascade);
	}
}