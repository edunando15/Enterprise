using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esame_Enterprise.Application.Models.Dto
{
    public class BookCategoryDto
    {

        public int BookId { get; set; }

        public int CategoryId { get; set; }

        public CategoryDto Category { get; set; }

        public BookDto Book { get; set; }

    }
}
