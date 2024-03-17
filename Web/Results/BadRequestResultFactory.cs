using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Esame_Enterprise.Web.Results
{
    public class BadRequestResultFactory : BadRequestObjectResult
    {
        public BadRequestResultFactory([ActionResultObjectValue] object? error) : base(error)
        {
        }
    }
}
