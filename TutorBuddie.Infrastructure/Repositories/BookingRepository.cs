using Microsoft.EntityFrameworkCore;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Repositories;
using TutorBuddie.Infrastructure.Data;

namespace TutorBuddie.Infrastructure.Repositories;

public class BookingRepository : IBookingRepository
{
	private readonly BuddyContext context;

	public IUnitOfWork UnitOfWork => context;

	public BookingRepository(BuddyContext context)
	{
		this.context = context;
	}

	public async Task<IEnumerable<Booking>> GetByTutorIdAsync(int tutorId)
	{
		return await context
			.Bookings
			.AsNoTracking()
			.Where(x => x.TutorId == tutorId)
			.ToListAsync();
	}

	public Booking Add(Booking details)
	{
		return context
			.Bookings
			.Add(details)
			.Entity;
	}

	public Booking Update(Booking details)
	{
		return context
			.Bookings
			.Update(details)
			.Entity;
	}
}