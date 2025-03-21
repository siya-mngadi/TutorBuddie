using System;

namespace TutorBuddie.Domain.Entities;

public class Tutor
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string Description { get; set; }
    public User User { get; set; }
	public IEnumerable<TutorCourse> Courses { get; set; }
	public IEnumerable<Review> Reviews { get; set; }
}
