using Model.Entities;
using FluentValidation;
using Esame_Enterprise.Application.Models.Requests;

namespace Esame_Enterprise.Application.Validators
{
    public class CreateCategoryRequestValidator : AbstractValidator<CreateCategoryRequest>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name can't be empty")
                .NotNull().WithMessage("Name can't be null");
        }

    }

}
