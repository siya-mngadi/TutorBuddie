using TutorBuddie.Domain.Entities;

namespace TutorBuddie.Domain.Responses;

public class ReviewResponse
{
	public int Id { get; set; }
	public int TutorId { get; set; }
	public string UserId { get; set; }
	public int Rating { get; set; }
	public string Comment { get; set; }
	public DateTime CreatedAtUtc { get; set; }
	public Tutor Tutor { get; set; }
	public User User { get; set; }
}