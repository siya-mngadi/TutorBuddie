using TutorBuddie.Domain.Requests.Payment;

namespace TutorBuddie.Domain.Services;

public interface IPaymentCheckoutService<T>
{
	Task<T> CheckoutAsync(CreatePaymentRequest request);
}