namespace TutorBuddie.Domain.Requests.Review;

public class UpdateReviewRequest
{
	public int Id { get; set; }
	public int Rating { get; set; }
	public string Comment { get; set; }
}