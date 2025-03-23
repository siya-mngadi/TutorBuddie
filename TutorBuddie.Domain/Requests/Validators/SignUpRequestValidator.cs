using FluentValidation;
using TutorBuddie.Domain.Requests.User;

namespace TutorBuddie.Domain.Requests.Validators;

public class SignUpRequestValidator : AbstractValidator<SignUpRequest>
{
	public SignUpRequestValidator()
	{
		RuleFor(x => x.Name)
			.NotNull()
			.NotEmpty()
			.WithMessage("Invalid name");

		RuleFor(x => x.Email)
			.NotNull()
			.NotEmpty()
			.EmailAddress()
			.WithMessage("Invalid email address");

		RuleFor(x => x.Password)
			.NotNull()
			.NotEmpty()
			.WithMessage("Invalid password")
			.MinimumLength(6)
			.WithMessage("Password must be at least 6 characters");
	}
}