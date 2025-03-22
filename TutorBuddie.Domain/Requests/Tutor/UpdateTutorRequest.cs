namespace TutorBuddie.Domain.Requests.Tutor;

public class UpdateTutorRequest
{
	public int Id { get; set; }
	public string Description { get; set; }
	public decimal PricePerHour { get; set; }
}