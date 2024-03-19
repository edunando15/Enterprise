using Esame_Enterprise.Application.Models.Requests;
using FluentValidation;
using Model.Context;
using Model.Repositories;

namespace Esame_Enterprise.Application.Validators
{
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryRequest>
    {

        public DeleteCategoryValidator()
        {
            RuleFor(c => c.Id).NotNull()
                .WithMessage("Category id can't be null.");
            RuleFor(c => c.Id).NotEmpty()
                .WithMessage("Category id can't be empty.");
            RuleFor(c => c.Id).Custom(ValidateCategoryDeletion);
        }

        private void ValidateCategoryDeletion(int id, ValidationContext<DeleteCategoryRequest> context)
        {
            if (id <= 0)
            {
                context.AddFailure("Id can't be negative or zero.");
            }
            BookCategoryRepository bookCategoryRepository = new BookCategoryRepository(new LibraryContext());
            CategoryRepository categoryRepository = new CategoryRepository(new LibraryContext());
            if(!categoryRepository.Exists(id))
            {
                context.AddFailure("Can't delete a category that doesn't exist.");
            }
            if(!bookCategoryRepository.IsDeleatable(id))
            {
                context.AddFailure("A category can't be deleted if there are some books associated with it. Delete books before deleting category.");
            }
        }

    }
}
