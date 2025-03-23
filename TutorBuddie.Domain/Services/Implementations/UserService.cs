using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using TutorBuddie.Domain.Configuration;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Enums;
using TutorBuddie.Domain.Repositories;
using TutorBuddie.Domain.Requests.User;
using TutorBuddie.Domain.Responses;

namespace TutorBuddie.Domain.Services.Implementations;

public class UserService : IUserService
{
	private readonly AuthenticationSettings _authenticationSettings;
	private readonly IUserRepository _userRepository;
	private readonly ITutorRepository _tutorRepository;
	private readonly IMapper _mapper;

	public UserService(
		IUserRepository userRepository, 
		ITutorRepository tutorRepository, 
		IMapper mapper, 
		IOptions<AuthenticationSettings> settings)
	{
		_userRepository = userRepository;
		_tutorRepository = tutorRepository;
		_mapper = mapper;
		_authenticationSettings = settings.Value;
	}

	public async Task<UserResponse> GetUserAsync(string email, CancellationToken cancellation = default)
	{
		var response = await _userRepository.GetByEmailAsync(email, cancellation);
		return _mapper.Map<UserResponse>(response);
	}

	public async Task LogoutAsync()
	{
		await _userRepository.LogoutAsync();
	}

	public async Task<UserResponse> SignUpAsync(SignUpRequest request, CancellationToken cancellation = default)
	{
		var user = new User()
		{
			Email = request.Email,
			Name = request.Name,
			Role = request.IsTutor ? Role.Tutor : Role.User
		};

		var response = await _userRepository.SignUpAsync(user, request.Password, cancellation);

		if (!response) return null;

		var result = await _userRepository.GetByEmailAsync(request.Email, cancellation);

		if(request.IsTutor) _ = _tutorRepository.Add(new Tutor { UserId = result.Id});

		return _mapper.Map<UserResponse>(result);
	}

	public async Task<TokenResponse> SignInAsync(SignInRequest request, CancellationToken cancellation = default)
	{
		var response = await _userRepository.AuthenticateAsync(request.Email, request.Email, cancellation);
		return !response
			? null
			: new TokenResponse
			{
				Token = GenerateSecurityToken(request)
			};
	}

	private string GenerateSecurityToken(SignInRequest request)
	{
		var tokenHandler = new JwtSecurityTokenHandler();
		var key = Encoding.ASCII.GetBytes(_authenticationSettings.Secret);
		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Subject = new ClaimsIdentity(new[]
			{
				new Claim(ClaimTypes.Email, request.Email)
			}),
			Expires = DateTime.UtcNow.AddDays(_authenticationSettings.ExpirationDays),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.RsaSha256Signature)
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);
		return tokenHandler.WriteToken(token);
	}
}