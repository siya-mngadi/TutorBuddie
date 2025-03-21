using TutorBuddie.Domain.Entities;

namespace TutorBuddie.Domain.Repositories;

public interface ICourseRepository
{
	Task<IEnumerable<Tutor>> GetAsync();
	Task<Tutor> GetAsync(int id);
	Tutor Add(Tutor details);
	Task Delete (int id);
}