using TutorBuddie.Domain.Entities;

namespace TutorBuddie.Domain.Responses;

public class TutorCourseResponse
{
	public int TutorId { get; set; }
	public Tutor Tutor { get; set; }
	public int CourseId { get; set; }
	public Course Course { get; set; }
}