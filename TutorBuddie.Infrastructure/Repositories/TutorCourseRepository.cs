using Microsoft.EntityFrameworkCore;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Repositories;
using TutorBuddie.Infrastructure.Data;

namespace TutorBuddie.Infrastructure.Repositories;

public class TutorCourseRepository : ITutorCourseRepository
{
	private readonly BuddyContext context;

	public IUnitOfWork UnitOfWork => context;

	public TutorCourseRepository(BuddyContext context)
	{
		this.context = context;
	}

	public async Task<IEnumerable<TutorCourse>> GetByTutorIdAsync(int tutorId)
	{
		return await context
			.TutorCourses
			.AsNoTracking()
			.Where(x => x.TutorId == tutorId)
			.ToListAsync();
	}

	public TutorCourse Add(int tutorId, int courseId)
	{
		return context
			.TutorCourses
			.Add(new TutorCourse
			{
				TutorId = tutorId,
				CourseId = courseId
			})
			.Entity;
	}

	public async Task<bool> Delete(int tutorId, int courseId)
	{
		 var tutorCourse = await context.TutorCourses.FirstOrDefaultAsync(x => x.TutorId == tutorId && x.CourseId == courseId);
		 if (tutorCourse is null) return false;
		 context.TutorCourses.Remove(tutorCourse);
		 return true;
	}
}