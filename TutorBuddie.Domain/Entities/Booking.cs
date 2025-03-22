using TutorBuddie.Domain.Enums;

namespace TutorBuddie.Domain.Entities;

public class Booking
{
	public int Id { get; set; }
	public string UserId { get; set; }
	public int TutorId { get; set; }
	public int CourseId { get; set; }
	public DateTime BookedAtUtc { get; set; }
	public Status  Status { get; set; }
	public User User { get; set; }
	public TutorCourse TutorCourse;
}
