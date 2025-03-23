using Microsoft.AspNetCore.Mvc;
using TutorBuddie.Domain.Requests.Payment;
using TutorBuddie.Domain.Services;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;

namespace TutorBuddie.Api.Controllers;

[Authorize]
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}")]
public class PaymentController : ControllerBase
{
	private readonly IPaymentService _service;
	private readonly IPaymentCheckoutService<string> _paymentService;

	public PaymentController(IPaymentService service, IPaymentCheckoutService<string> paymentService)
	{
		this._service = service;
		_paymentService = paymentService;
	}

	[HttpGet("tutors/{tutorId:int}/payments")]
	public async Task<IActionResult> GetByTutor(int tutorId)
	{
		var results = await _service.GetByTutorIdAsync(tutorId);
		return Ok(results);
	}

	[HttpGet("payments/{id:required}")]
	public async Task<IActionResult> Get(string id)
	{
		var results = await _service.GetAsync(id);
		return Ok(results);
	}

	[HttpPost("payments")]
	public async Task<IActionResult> Create(CreatePaymentRequest request)
	{
		var sessionId = await _paymentService.CheckoutAsync(request);
		request.Id = sessionId;
		var result = _service.Add(request);
		return Ok(result);
	}
}