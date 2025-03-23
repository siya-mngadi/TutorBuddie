using AutoMapper;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Responses;

namespace TutorBuddie.Domain.Mappers;

public class UserProfile : Profile
{
	public UserProfile()
	{
		CreateMap<User, UserResponse>();
	}
}