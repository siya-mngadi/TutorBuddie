using Microsoft.EntityFrameworkCore;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Repositories;
using TutorBuddie.Infrastructure.Data;

namespace TutorBuddie.Infrastructure.Repositories;

public class CourseRepository : ICourseRepository
{
	private readonly BuddyContext context;

	public IUnitOfWork UnitOfWork => context;

	public CourseRepository(BuddyContext context)
	{
		this.context = context;
	}

	public async Task<IEnumerable<Tutor>> GetAsync()
	{
		
		return await context
			.Tutors
			.AsNoTracking()
			.ToListAsync();
	}

	public async Task<Tutor> GetAsync(int id)
	{
		return await context
			.Tutors
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.Id == id);
	}

	public Tutor Add(Tutor details)
	{
		return context
			.Tutors
			.Add(details)
			.Entity;
	}

	public Task Delete(int id)
	{
		context.Tutors.Remove(new Tutor { Id = id });
		return Task.CompletedTask;
	}
}