﻿using Esame_Enterprise.Application.Abstractions.Models.Dto;
using Model.Entities;

namespace Esame_Enterprise.Application.Models.Dto
{
    public class CategoryDto : GenericDto<Category>
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public CategoryDto() { }

        public CategoryDto(Category category)
        {
            Id = category.Id;
            Name = category.Name;
        }

        public Category ToEntity()
        {
            return new Category
            {
                Id = Id,
                Name = Name
            };
        }

    }
}
