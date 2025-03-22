using TutorBuddie.Domain.Entities;

namespace TutorBuddie.Domain.Responses;

public class TutorResponse
{
	public int Id { get; set; }
	public string UserId { get; set; }
	public string Description { get; set; }
	public User User { get; set; }
	public decimal AmountPerHour { get; set; }
	public IEnumerable<TutorCourse> Courses { get; set; }
	public IEnumerable<Review> Reviews { get; set; }
}