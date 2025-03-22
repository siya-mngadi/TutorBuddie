using Microsoft.EntityFrameworkCore;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Repositories;
using TutorBuddie.Infrastructure.Data;

namespace TutorBuddie.Infrastructure.Repositories;

public class ReviewRepository : IReviewRepository
{
	private readonly BuddyContext context;

	public IUnitOfWork UnitOfWork => context;

	public ReviewRepository(BuddyContext context)
	{
		this.context = context;
	}

	public async Task<IEnumerable<Review>> GetByTutorIdAsync(int tutorId)
	{
		return await context
			.Reviews
			.AsNoTracking()
			.Where(x => x.TutorId == tutorId)
			.ToListAsync();
	}

	public Review Add(Review details)
	{
		return context.Reviews
			.Add(details)
			.Entity;
	}
}