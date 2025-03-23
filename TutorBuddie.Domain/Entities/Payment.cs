using System;

namespace TutorBuddie.Domain.Entities;

public class Payment
{
	public string Id { get; set; }
	public int PaymentId { get; set; }
	public int BookingId { get; set; }
	public decimal Amount { get; set; }
	public DateTime PaidAtUtc { get; set; }
	public Booking Booking { get; set; }
}
