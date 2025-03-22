using System.Security.Claims;
using Asp.Versioning;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TutorBuddie.Domain.Requests.User;
using TutorBuddie.Domain.Services;

namespace TutorBuddie.Api.Controllers;

[Authorize]
[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/users")]
public class UserController : ControllerBase
{
	private readonly IUserService _service;

	public UserController(IUserService service)
	{
		this._service = service;
	}

	[HttpGet]
	public async Task<IActionResult> Get()
	{
		var claim = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email);
		if (claim == null) return Unauthorized();

		var token = await _service.GetUserAsync(claim.Value);
		return Ok(token);
	}

	[AllowAnonymous]
	[HttpPost("auth")]
	public async Task<IActionResult>
		SignIn(SignInRequest request)
	{
		var token = await _service.SignInAsync(request);
		if (token == null) return BadRequest();
		return Ok(token);
	}

	[AllowAnonymous]
	[HttpPost]
	public async Task<IActionResult>
		SignUp(SignUpRequest request)
	{
		var user = await _service.SignUpAsync(request);
		if (user == null) return BadRequest();
		return CreatedAtAction(nameof(Get), new { }, user);
	}
}