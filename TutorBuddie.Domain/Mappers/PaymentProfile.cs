using AutoMapper;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Responses;
using TutorBuddie.Domain.Requests.Payment;

namespace TutorBuddie.Domain.Mappers;

public class PaymentProfile : Profile
{
	public PaymentProfile()
	{
		CreateMap<Payment, PaymentResponse>();
		CreateMap<CreatePaymentRequest, Payment>();
	}
}