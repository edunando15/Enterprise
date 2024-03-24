using Esame_Enterprise.Application.Extensions;
using Esame_Enterprise.Application.Models.Requests;
using FluentValidation;

namespace Esame_Enterprise.Application.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Email)
                .NotNull().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email");
            RuleFor(x => x.Password)
                .NotNull().WithMessage("Password is required")
                .MinimumLength(6).WithMessage("Password must be at least 6 characters")
                .RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$",
                "Password must contain at least: a lower case character, a upper case one, a number, and a special character.");

        }

    }

}
