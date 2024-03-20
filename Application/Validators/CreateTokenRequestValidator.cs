using Esame_Enterprise.Application.Extensions;
using Esame_Enterprise.Application.Models.Requests;
using FluentValidation;

namespace Esame_Enterprise.Application.Validators
{
    public class CreateTokenRequestValidator : AbstractValidator<CreateTokenRequest>
    {

        public CreateTokenRequestValidator()
        {
            RuleFor(r => r.Email)
                .NotEmpty()
                .WithMessage("Email can't be empty.")
                .NotNull()
                .WithMessage("Email can't be null.");
            RuleFor(r => r.Password)
                .NotEmpty()
                .WithMessage("Password can't be empty.")
                .NotNull()
                .WithMessage("Password can't be null.")
                .MinimumLength(5)
                .WithMessage("The password must be at least 5 characters long.")
                .RegEx("^(?=.*[A-Z])(?=.*[a-z])(?=.*\\d)(?=.*[!@#$%^&*()_+{}\\[\\]:;<>,.?~\\\\-]).{6,}$",
                "Password must be at least 5 characters long and it must contain at least one lower case character, one upper case character, and one special character.");
        }

    }
}
