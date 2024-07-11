using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySocialNetwork.Api.Contracts.UserProfiles.Requests;
using MySocialNetwork.Api.Contracts.UserProfiles.Responses;
using MySocialNetwork.Application.UserProfiles.Commands;

namespace MySocialNetwork.Api.Controllers.v1
{
    [ApiController]
    [Route(ApiRoutes.BaseUrl)]
    public class UserProfilesController : ControllerBase
    {
        public readonly IMediator _mediator;
        public readonly IMapper _mapper;
        public UserProfilesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllProfiles()
        {

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProfileAsync([FromBody] UserProfileCreate userProfile)
        {
            var command = _mapper.Map<CreateUserCommand>(userProfile);
            
            var response = await _mediator.Send(command);

            var userProfileResponse = _mapper.Map<UserProfileResponse>(response);

            return Ok(userProfileResponse);
        }
    }
}
