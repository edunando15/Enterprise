﻿using Esame_Enterprise.Application.Abstractions.Models.Dto;
using Model.Entities;

namespace Esame_Enterprise.Application.Models.Dto
{
    public class BookCategoryDto : GenericDto<BookCategory>
    {

        public int BookId { get; set; }

        public int CategoryId { get; set; }

        public CategoryDto Category { get; set; }

        public BookDto Book { get; set; }

        public BookCategory ToEntity()
        {
            return new BookCategory()
            {
                BookId = BookId,
                CategoryId = CategoryId,
                Category = Category.ToEntity(),
                Book = Book.ToEntity()
            };
        }

    }
}
