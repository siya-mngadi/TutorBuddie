using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Repositories;

namespace TutorBuddie.Infrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
	public Task<IEnumerable<Review>> GetByTutorIdAsync(int tutorId)
	{
		throw new NotImplementedException();
	}

	public Review Add(Review details)
	{
		throw new NotImplementedException();
	}
}