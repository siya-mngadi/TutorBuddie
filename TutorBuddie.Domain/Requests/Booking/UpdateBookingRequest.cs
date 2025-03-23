using TutorBuddie.Domain.Enums;

namespace TutorBuddie.Domain.Requests.Booking;

public class UpdateBookingRequest
{
	public Status Status { get; set; }
	public DateTime StartAtUtc { get; set; }
}