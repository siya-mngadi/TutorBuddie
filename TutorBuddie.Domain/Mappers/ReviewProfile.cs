using AutoMapper;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Responses;
using TutorBuddie.Domain.Requests.Review;

namespace TutorBuddie.Domain.Mappers;

public class ReviewProfile : Profile
{
	public ReviewProfile()
	{
		CreateMap<Review, ReviewResponse>();
		CreateMap<CreateReviewRequest, Review>();
		CreateMap<UpdateReviewRequest, Review>();
	}
}