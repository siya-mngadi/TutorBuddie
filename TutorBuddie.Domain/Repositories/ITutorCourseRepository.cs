using TutorBuddie.Domain.Entities;

namespace TutorBuddie.Domain.Repositories;

public interface ITutorCourseRepository
{
	Task<IEnumerable<TutorCourse>> GetByTutorIdAsync(int tutorId);
	TutorCourse Add(int tutorId,int courseId);
	Task<bool> Delete(int tutorId, int courseId);
}