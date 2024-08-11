using Microsoft.AspNetCore.Mvc.Filters;
using MySocialNetwork.Api.Contracts.Common;
using MySocialNetwork.Application.Enums;
using System.Text.RegularExpressions;

namespace MySocialNetwork.Api.Filters
{
    public class ValidateEmailAttribute : ActionFilterAttribute
    {
        private readonly string _emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
        private readonly string _email;
        public ValidateEmailAttribute(string email)
        {
            _email = email;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {

            if (IsValidEmail(_email) is true)
                return;

            //var errorResponse = new ApiErrorResponse()
            //{
            //    StatusCode = ErrorCode.BadRequest,
            //    StatusPhrase = "Bad Request",
            //    Errors = [new(ErrorCode.BadRequest,$"{}")]
            //};
        }

        private bool IsValidEmail(string email)
        {
            if (string.IsNullOrEmpty(email))
                return false;

            var regex = new Regex(_emailPattern);

            return regex.IsMatch(email);
        }
    }
}
