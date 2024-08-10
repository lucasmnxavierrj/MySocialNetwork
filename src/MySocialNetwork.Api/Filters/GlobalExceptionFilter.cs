using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MySocialNetwork.Api.Contracts.Common;

namespace MySocialNetwork.Api.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(ExceptionContext context)
        {
            var response = new ApiErrorResponse
            {
                StatusPhrase = "Internal Server Error",
                StatusCode = 500
            };

            response.Errors.Add(context.Exception.Message);

            context.Result = new ObjectResult(response)
            {
                StatusCode = 500,
            };
        }
    }
}
