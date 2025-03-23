using AutoMapper;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Repositories;
using TutorBuddie.Domain.Requests.Payment;
using TutorBuddie.Domain.Responses;

namespace TutorBuddie.Domain.Services.Implementations;

public class PaymentService : IPaymentService
{
	private readonly IMapper _mapper;
	private readonly IPaymentRepository _repository;

	public PaymentService(IMapper mapper, IPaymentRepository repository)
	{
		_mapper = mapper;
		_repository = repository;
	}

	public async Task<IEnumerable<PaymentResponse>> GetByTutorIdAsync(int tutorId)
	{
		var result = await _repository.GetByTutorIdAsync(tutorId);
		return _mapper.Map<IEnumerable<PaymentResponse>>(result);
	}

	public async Task<PaymentResponse> GetAsync(string id)
	{
		var result = await _repository.GetAsync(id);
		return _mapper.Map<PaymentResponse>(result);
	}

	public PaymentResponse Add(CreatePaymentRequest request)
	{
		var result = _repository.Add(_mapper.Map<Payment>(request));
		return _mapper.Map<PaymentResponse>(result);
	}
}