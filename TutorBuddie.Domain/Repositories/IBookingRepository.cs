using TutorBuddie.Domain.Entities;

namespace TutorBuddie.Domain.Repositories;

public interface IBookingRepository
{
	Task<IEnumerable<Booking>> GetByTutorIdAsync(int tutorId);
	Booking Add(Booking details);
}