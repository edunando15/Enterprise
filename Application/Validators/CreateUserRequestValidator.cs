using Esame_Enterprise.Application.Models.Requests;
using FluentValidation;

namespace Esame_Enterprise.Application.Validators
{
    public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
    {
        public CreateUserRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name can't be empty")
                .NotNull().WithMessage("Name is required");
            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Surname can't be empty")
                .NotNull().WithMessage("Surname is required");
            RuleFor(x => x.Email)
                .NotNull().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid Email");
            RuleFor(x => x.Password)
                .NotNull().WithMessage("Password is required")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters");
        }

    }

}
