using AutoMapper;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Requests.Tutor;
using TutorBuddie.Domain.Responses;

namespace TutorBuddie.Domain.Mappers;

public class TutorProfile : Profile
{
	public TutorProfile()
	{
		CreateMap<Tutor, TutorResponse>();
		CreateMap<TutorCourse, TutorCourseResponse>();
		CreateMap<CreateTutorRequest, Tutor>();
		CreateMap<UpdateTutorRequest, Tutor>();
	}
}