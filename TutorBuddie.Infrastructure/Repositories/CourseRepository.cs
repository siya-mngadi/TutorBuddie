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

	public async Task<IEnumerable<Course>> GetAsync()
	{
		
		return await context
			.Courses
			.AsNoTracking()
			.ToListAsync();
	}

	public async Task<Course> GetAsync(int id)
	{
		return await context
			.Courses
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.Id == id);
	}

	public Course Add(Course details)
	{
		return context
			.Courses
			.Add(details)
			.Entity;
	}

	public Course Update(Course details)
	{
		return context
			.Courses
			.Update(details)
			.Entity;
	}

	public Task Delete(int id)
	{
		context.Courses.Remove(new Course { Id = id });
		return Task.CompletedTask;
	}
}