using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorBuddie.Domain.Requests.Booking;
using TutorBuddie.Domain.Services;

namespace TutorBuddie.Api.Controllers;

[Authorize]
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}")]
public class BookingController : ControllerBase
{
	private readonly IBookingService _service;

	public BookingController(IBookingService service)
	{
		this._service = service;
	}

	[HttpGet("tutors/{tutorId:int}/bookings")]
	public async Task<IActionResult> GetByTutor(int tutorId)
	{
		var results = await _service.GetByTutorIdAsync(tutorId);
		return Ok(results);
	}

	[HttpPatch("bookings")]
	public IActionResult Update(UpdateBookingRequest request)
	{
		var result = _service.Update(request);
		if (result == null) return BadRequest();
		return Ok(result);
	}

	[HttpPost("bookings")]
	public IActionResult Create(CreateBookingRequest request)
	{
		var result = _service.Add(request);
		if (result == null) return BadRequest();
		return Ok(result);
	}
}