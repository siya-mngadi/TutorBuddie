using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Requests.Tutor;
using TutorBuddie.Domain.Responses;

namespace TutorBuddie.Domain.Services;

public interface ITutorService
{
	Task<IEnumerable<TutorResponse>> GetAsync();
	Task<TutorResponse> GetAsync(int id);
	TutorResponse Add(CreateTutorRequest request);
	TutorResponse Update(UpdateTutorRequest request);
	Task<IEnumerable<TutorCourseResponse>> GetByTutorIdAsync(int tutorId);
	TutorCourseResponse Add(int tutorId, int courseId);
	Task<bool> Delete(int tutorId, int courseId);
}