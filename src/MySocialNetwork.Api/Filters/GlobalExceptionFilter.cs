using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MySocialNetwork.Api.Contracts.Common;

namespace MySocialNetwork.Api.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var response = new ApiErrorResponse();

            response.StatusCode = 500;
            response.StatusPhrase = "Internal Server Error";
            response.Errors.Add(context.Exception.Message);

            context.Result = new ObjectResult(response)
            {
                StatusCode = 500,
            };
        }
    }
}
