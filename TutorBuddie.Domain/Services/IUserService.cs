using TutorBuddie.Domain.Requests.User;
using TutorBuddie.Domain.Responses;

namespace TutorBuddie.Domain.Services;

public interface IUserService
{
	Task<UserResponse> GetUserAsync(string email, CancellationToken cancellation = default);
	Task<UserResponse> SignUpAsync(SignUpRequest request, CancellationToken cancellation = default);
	Task<TokenResponse> SignInAsync(SignInRequest request, CancellationToken cancellation = default);
}