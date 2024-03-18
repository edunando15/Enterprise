using Esame_Enterprise.Application.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esame_Enterprise.Application.Models.Requests
{
    public class GetBooksRequest
    {
        public int From { get; set; }
        public int Num { get; set; }
        public string OrderBy { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime PublicationDate { get; set; }
        public CategoryDto Category { get; set; }

    }
}
