using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TutorBuddie.Domain.Entities;
using TutorBuddie.Domain.Repositories;

namespace TutorBuddie.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
	private readonly SignInManager<User> singInManager;
	private readonly UserManager<User> userManager;

	public UserRepository(UserManager<User> userManager, SignInManager<User> singInManager)
	{
		this.userManager = userManager;
		this.singInManager = singInManager;
	}

	public async Task<bool> AuthenticateAsync(string email, string password, CancellationToken cancellationToken = default)
	{
		var result = await singInManager.PasswordSignInAsync(email, password, false, false);
		return result.Succeeded;
	}

	public async Task<bool> SignUpAsync(User user, string password, CancellationToken cancellationToken = default)
	{
		var result = await userManager.CreateAsync(user, password);
		return result.Succeeded;
	}

	public async Task<User> GetByEmailAsync(string requestEmail, CancellationToken cancellationToken = default)
	{
		return await userManager.Users.FirstOrDefaultAsync(x => x.Email == requestEmail, cancellationToken);
	}
}