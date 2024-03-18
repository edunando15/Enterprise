using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Esame_Enterprise.Web.Results
{
    public class BadRequestResultFactory : BadRequestObjectResult
    {
        public BadRequestResultFactory([ActionResultObjectValue] object? error) : base(error)
        {
        }
    }
}
