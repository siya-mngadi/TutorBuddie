using TutorBuddie.Domain.Entities;

namespace TutorBuddie.Domain.Repositories;

public interface ITutorRepository
{
	Task<IEnumerable<Tutor>> GetAsync();
	Task<Tutor> GetAsync(int id);
	Tutor Add(Tutor details);
}