using TutorBuddie.Domain.Entities;

namespace TutorBuddie.Domain.Responses;

public class PaymentResponse
{
	public string Id { get; set; }
	public int PaymentId { get; set; }
	public int BookingId { get; set; }
	public decimal Amount { get; set; }
	public DateTime PaidAtUtc { get; set; }
	public Booking Booking { get; set; }
}