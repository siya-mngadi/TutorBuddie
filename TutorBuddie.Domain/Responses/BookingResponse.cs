using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Enums;

namespace TutorBuddie.Domain.Responses;

public class BookingResponse
{
	public int Id { get; set; }
	public string UserId { get; set; }
	public int TutorId { get; set; }
	public int CourseId { get; set; }
	public DateTime BookedAtUtc { get; set; }
	public DateTime StartAtUtc { get; set; }
	public Status Status { get; set; }
	public User User { get; set; }
	public TutorCourse TutorCourse;
}