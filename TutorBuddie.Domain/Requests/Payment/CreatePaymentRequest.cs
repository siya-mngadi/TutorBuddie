namespace TutorBuddie.Domain.Requests.Payment;

public class CreatePaymentRequest
{
	public int BookingId { get; set; }
	public int PaymentId { get; set; }
	public decimal Amount { get; set; }
}