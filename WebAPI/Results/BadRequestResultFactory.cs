using Esame_Enterprise.Application.Models.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Esame_Enterprise.Web.Results
{
    public class BadRequestResultFactory : BadRequestObjectResult
    {
        public BadRequestResultFactory(ActionContext context) : base(new BadResponse())
        {
            var resultErrors = new List<string>();
            foreach(var key in context.ModelState)
            {
                var errors = key.Value.Errors;
                foreach(var error in errors)
                {
                    resultErrors.Add(error.ErrorMessage);
                }
            }
            var response = (BadResponse)Value;
            response.Errors = resultErrors;
        }
    }
}
