using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorBuddie.Domain.Requests.Review;
using TutorBuddie.Domain.Services;

namespace TutorBuddie.Api.Controllers;

[Authorize]
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}")]
public class ReviewController : ControllerBase
{
	private readonly IReviewService _service;

	public ReviewController(IReviewService service)
	{
		this._service = service;
	}

	[HttpGet("tutors/{tutorId:int}/reviews")]
	public async Task<IActionResult> GetByTutor(int tutorId)
	{
		var results = await _service.GetByTutorIdAsync(tutorId);
		return Ok(results);
	}

	[HttpPatch("reviews")]
	public IActionResult Update(UpdateReviewRequest request)
	{
		var result = _service.Update(request);
		if (result == null) return BadRequest();
		return Ok(result);
	}

	[HttpPost("reviews")]
	public IActionResult Create(CreateReviewRequest request)
	{
		var result = _service.Add(request);
		if (result == null) return BadRequest();
		return Ok(result);
	}
}