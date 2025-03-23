using TutorBuddie.Domain.Enums;

namespace TutorBuddie.Domain.Requests.Booking;

public class CreateBookingRequest
{
	public string UserId { get; set; }
	public int TutorId { get; set; }
	public int CourseId { get; set; }
	public DateTime StartAtUtc { get; set; }
}