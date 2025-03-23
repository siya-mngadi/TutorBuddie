using Stripe;
using Stripe.Checkout;
using TutorBuddie.Domain.Requests.Payment;
using TutorBuddie.Domain.Services;

namespace TutorBuddie.Infrastructure.Services;

public class StripePaymentService : IPaymentCheckoutService<string>
{
	public async Task<string> CheckoutAsync(CreatePaymentRequest request)
	{
		var options = new SessionCreateOptions()
		{
			PaymentMethodTypes = ["card"],
			LineItems =
			[
				new SessionLineItemOptions
				{
					PriceData = new SessionLineItemPriceDataOptions
					{
						Currency = "zar",
						UnitAmount = (long)request.Amount,
						ProductData = new SessionLineItemPriceDataProductDataOptions
						{
							Name = "Booked Tutor Session"
						}
					},
					Quantity = 1
				}
			],
			Mode = "payment",
			SuccessUrl = "https://localhost:5410/success",
			CancelUrl = "https://localhost:5410/cancel"
		};

		var service = new SessionService();
		var session = await service.CreateAsync(options, new RequestOptions
		{
			IdempotencyKey = Guid.NewGuid().ToString()
		});

		return session.Id;
	}
}