using Microsoft.EntityFrameworkCore;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Repositories;
using TutorBuddie.Infrastructure.Data;

namespace TutorBuddie.Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
	private readonly BuddyContext context;

	public IUnitOfWork UnitOfWork => context;

	public PaymentRepository(BuddyContext context)
	{
		this.context = context;
	}

	public async Task<IEnumerable<Payment>> GetByTutorIdAsync(int tutorId)
	{
		return await context
			.Payments
			.AsNoTracking()
			.Where(x => x.Booking.TutorId == tutorId)
			.ToListAsync();
	}

	public async Task<Payment> GetAsync(int id)
	{
		return await context
			.Payments
			.AsNoTracking()
			.FirstOrDefaultAsync(x => x.Id == id);
	}

	public Payment Add(Payment details)
	{
		return context
			.Payments
			.Add(details)
			.Entity;
	}
}