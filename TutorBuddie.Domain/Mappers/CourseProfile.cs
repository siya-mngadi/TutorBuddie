using AutoMapper;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Requests.Course;
using TutorBuddie.Domain.Responses;

namespace TutorBuddie.Domain.Mappers;

public class CourseProfile : Profile
{
	public CourseProfile()
	{
		CreateMap<Course, CourseResponse>();
		CreateMap<CreateCourseRequest, Course>();
		CreateMap<UpdateCourseRequest, Course>();
	}
}