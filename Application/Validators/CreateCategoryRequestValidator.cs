﻿using Model.Entities;
using FluentValidation;

namespace Esame_Enterprise.Application.Validators
{
    public class CreateCategoryRequestValidator : AbstractValidator<Category>
    {
        public CreateCategoryRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name can't be empty")
                .NotNull().WithMessage("Name can't be null");
        }

    }

}