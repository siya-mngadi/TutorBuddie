using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using TutorBuddie.Domain.Services;
using TutorBuddie.Domain.Requests.Tutor;
using Microsoft.AspNetCore.Authorization;

namespace TutorBuddie.Api.Controllers;

[Authorize]
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/tutors")]
public class TutorController : ControllerBase
{
	private readonly ITutorService _service;

	public TutorController(ITutorService service)
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
	public IActionResult Update(UpdateTutorRequest request)
	{
		var result = _service.Update(request);
		if (result == null) return BadRequest();
		return Ok(result);
	}

	[HttpPost]
	public IActionResult Create(CreateTutorRequest request)
	{
		var result =  _service.Add(request);
		if (result == null) return BadRequest();
		return CreatedAtAction(nameof(Get), new {result.Id }, result);
	}
}