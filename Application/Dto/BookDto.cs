using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esame_Enterprise.Application.Dto
{
    public class BookDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Author { get; set; }

        public DateTime PublicationDate { get; set; }

        public string Publisher { get; set; }

    }
}
