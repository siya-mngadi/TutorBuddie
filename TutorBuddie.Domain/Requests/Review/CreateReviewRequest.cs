namespace TutorBuddie.Domain.Requests.Review;

public class CreateReviewRequest
{
	public int Rating { get; set; }
	public string Comment { get; set; }
	public int TutorId { get; set; }
}