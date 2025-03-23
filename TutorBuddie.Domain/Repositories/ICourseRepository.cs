using TutorBuddie.Domain.Entities;

namespace TutorBuddie.Domain.Repositories;

public interface ICourseRepository
{
	Task<IEnumerable<Course>> GetAsync();
	Task<Course> GetAsync(int id);
	Course Add(Course details);
	Course Update(Course details);
	Task Delete (int id);
}