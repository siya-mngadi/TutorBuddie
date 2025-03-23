using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Requests.Payment;
using TutorBuddie.Domain.Responses;

namespace TutorBuddie.Domain.Services;

public interface IPaymentService
{
	Task<IEnumerable<PaymentResponse>> GetByTutorIdAsync(int tutorId);
	Task<PaymentResponse> GetAsync(string id);
	PaymentResponse Add(CreatePaymentRequest request);
}