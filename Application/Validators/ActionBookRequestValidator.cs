using FluentValidation;
using Model.Entities;

namespace Esame_Enterprise.Application.Validators
{
    public class ActionBookRequestValidator : AbstractValidator<Book>
    {
        public ActionBookRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Title can't be empty")
                .NotNull().WithMessage("Title is required");
            RuleFor(x => x.Author)
                .NotEmpty().WithMessage("Author can't be empty")
                .NotNull().WithMessage("Author is required");
            RuleFor(x => x.Publisher)
                .NotEmpty().WithMessage("Publisher can't be empty")
                .NotNull().WithMessage("Publisher is required");
            RuleFor(x => x.PublicationDate)
                .NotEmpty().WithMessage("Publication Date can't be empty")
                .NotNull().WithMessage("Publication Date is required")
                .LessThan(System.DateTime.Now).WithMessage("Publication Date can't be in the future");
            RuleFor(x => x.BookCategories)
                .Must(x => x.Count > 0).WithMessage("At least one Book Category is required");
        }   

    }

}
