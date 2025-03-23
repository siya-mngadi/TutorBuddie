using AutoMapper;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Requests.Booking;
using TutorBuddie.Domain.Responses;

namespace TutorBuddie.Domain.Mappers;

public class BookingProfile : Profile
{
	public BookingProfile()
	{
		CreateMap<Booking, BookingResponse>();
		CreateMap<UpdateBookingRequest, Booking>();
		CreateMap<CreateBookingRequest, Booking>();
	}
}