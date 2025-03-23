using TutorBuddie.Domain.Entities;

namespace TutorBuddie.Domain.Repositories;

public interface IPaymentRepository
{
	Task<IEnumerable<Payment>> GetByTutorIdAsync(int tutorId);
	Task<Payment> GetAsync(string id);
	Payment Add(Payment details);
}