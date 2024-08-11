using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MySocialNetwork.Api.Contracts.Common;

namespace MySocialNetwork.Api.Filters
{
    public class ValidateGuidAttribute : ActionFilterAttribute
    {
        private readonly List<string> _keys;
        public ValidateGuidAttribute(params string[] keys)
        {
            _keys = keys.ToList();
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            bool hasError = false;

            var errorResponse = new ApiErrorResponse();

            _keys.ForEach(key =>
            {
                if (context.ActionArguments.TryGetValue(key, out var value) is false) 
                    return;

                if (Guid.TryParse(value?.ToString(), out var guid) is false)
                {
                    hasError = true;

                    errorResponse.Errors.Add($"The identifier for {key} is not a correct GUID format.");
                }
            });

            if (hasError)
            {
                errorResponse.StatusCode = 400;
                errorResponse.StatusPhrase = "Bad request";
                errorResponse.Timestamp = DateTime.Now;

                context.Result = new ObjectResult(errorResponse);
            }
        }
    }
}
