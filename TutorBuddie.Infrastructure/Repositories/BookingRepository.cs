using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Repositories;

namespace TutorBuddie.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
	public Task<IEnumerable<Booking>> GetByTutorIdAsync(int tutorId)
	{
		throw new NotImplementedException();
	}

	public Booking Add(Booking details)
	{
		throw new NotImplementedException();
	}
}