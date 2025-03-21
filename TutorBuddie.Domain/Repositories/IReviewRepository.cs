using TutorBuddie.Domain.Entities;

namespace TutorBuddie.Domain.Repositories;

public interface IReviewRepository
{
	Task<IEnumerable<Review>> GetByTutorIdAsync(int tutorId);
	Review Add(Review details);
}