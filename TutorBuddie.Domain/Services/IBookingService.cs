using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Requests.Booking;
using TutorBuddie.Domain.Responses;

namespace TutorBuddie.Domain.Services;

public interface IBookingService
{
	Task<IEnumerable<BookingResponse>> GetByTutorIdAsync(int tutorId);
	BookingResponse Add(CreateBookingRequest request);
	BookingResponse Update(UpdateBookingRequest request);
}