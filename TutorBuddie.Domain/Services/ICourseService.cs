using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Requests.Course;
using TutorBuddie.Domain.Requests.Tutor;
using TutorBuddie.Domain.Responses;

namespace TutorBuddie.Domain.Services;

public interface ICourseService
{
	Task<IEnumerable<CourseResponse>> GetAsync();
	Task<CourseResponse> GetAsync(int id);
	CourseResponse Add(CreateCourseRequest request);
	CourseResponse Update(UpdateCourseRequest request);
	Task Delete(int id);
}