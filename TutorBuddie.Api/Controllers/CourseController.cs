using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorBuddie.Domain.Requests.Course;
using TutorBuddie.Domain.Services;

namespace TutorBuddie.Api.Controllers;

[Authorize]
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/courses")]
public class CourseController : ControllerBase
{
	private readonly ICourseService _service;

	public CourseController(ICourseService service)
	{
		this._service = service;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll()
	{
		var results = await _service.GetAsync();
		return Ok(results);
	}

	[HttpGet("{id:int}")]
	public async Task<IActionResult> Get(int id)
	{
		var result = await _service.GetAsync(id);
		if (result == null) return NotFound();
		return Ok(result);
	}

	[HttpPatch]
	public IActionResult Update(UpdateCourseRequest request)
	{
		var result = _service.Update(request);
		if (result == null) return BadRequest();
		return Ok(result);
	}

	[HttpPost]
	public IActionResult Create(CreateCourseRequest request)
	{
		var result = _service.Add(request);
		if (result == null) return BadRequest();
		return CreatedAtAction(nameof(Get), new { result.Id }, result);
	}
}