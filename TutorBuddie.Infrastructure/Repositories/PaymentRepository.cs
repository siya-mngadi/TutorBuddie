using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Repositories;

namespace TutorBuddie.Infrastructure.Repositories;

public class PaymentRepository : IPaymentRepository
{
	public Task<IEnumerable<Payment>> GetByTutorIdAsync(int tutorId)
	{
		throw new NotImplementedException();
	}

	public Task<Payment> GetAsync(int id)
	{
		throw new NotImplementedException();
	}

	public Payment Add(Payment details)
	{
		throw new NotImplementedException();
	}
}