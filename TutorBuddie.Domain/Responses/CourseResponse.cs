using TutorBuddie.Domain.Entities;

namespace TutorBuddie.Domain.Responses;

public class CourseResponse
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public IEnumerable<TutorCourse> TutorCourses { get; set; }
}