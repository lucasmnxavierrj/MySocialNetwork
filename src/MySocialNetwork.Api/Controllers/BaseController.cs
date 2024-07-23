using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MySocialNetwork.Api.Contracts.Common;
using MySocialNetwork.Application.Enums;
using MySocialNetwork.Application.Models;

namespace MySocialNetwork.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private IMediator _mediatorInstance;
        private IMapper _mapperInstance;
        protected IMediator _mediator => _mediatorInstance ??= HttpContext.RequestServices.GetService<IMediator>();
        protected IMapper _mapper => _mapperInstance ??= HttpContext.RequestServices.GetService<IMapper>();

        protected IActionResult HandleErrorResponse(List<Error> errors)
        {
            var apiError = new ApiErrorResponse();

            if (errors.Any(e => e.Code == ErrorCode.NotFound))
            {
                var error = errors.FirstOrDefault(e => e.Code == ErrorCode.NotFound);

                apiError.StatusCode = (int)ErrorCode.NotFound;
                apiError.StatusPhrase = "Not Found";
                apiError.Errors.Add(error.Message);

                return NotFound(apiError);
            }

            apiError.StatusCode = (int)ErrorCode.BadRequest;
            apiError.StatusPhrase = "Bad request";
            errors.ForEach(e => apiError.Errors.Add(e.Message));
            return BadRequest(apiError);
        }
    }
}
