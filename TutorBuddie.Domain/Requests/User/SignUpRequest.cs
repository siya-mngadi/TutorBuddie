﻿namespace TutorBuddie.Domain.Requests.User;

public class SignUpRequest
{
	public string Name { get; set; }
	public string Email { get; set; }
	public string Password { get; set; }
	public bool IsTutor { get; set; }
}