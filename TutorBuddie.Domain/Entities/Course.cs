using System;

namespace TutorBuddie.Domain.Entities;

public class Course
{
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public IEnumerable<TutorCourse> TutorCourses { get; set; }
}
