using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySocialNetwork.Api.Contracts.UserProfiles.Requests;
using MySocialNetwork.Api.Contracts.UserProfiles.Responses;
using MySocialNetwork.Application.UserProfiles.Commands;
using MySocialNetwork.Application.UserProfiles.Queries;

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
        public async Task<IActionResult> GetAllProfiles()
        {
            var query = new GetAllUserProfilesQuery();
            var response = await _mediator.Send(query);

            var userProfiles = _mapper.Map<List<UserProfileResponse>>(response);

            return Ok(userProfiles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProfileAsync([FromBody] UserProfileCreate userProfile)
        {
            var command = _mapper.Map<CreateUserCommand>(userProfile);

            var response = await _mediator.Send(command);

            var userProfileResponse = _mapper.Map<UserProfileResponse>(response);

            return CreatedAtAction(nameof(GetUserProfileById), new { id = response.Id }, userProfileResponse);
        }

        [Route("{id}")]
        [HttpGet]
        public async Task<IActionResult> GetUserProfileById(string id)
        {
            var query = new GetUserProfileByIdQuery(id);

            var response = _mediator.Send(query);

            var userProfile = _mapper.Map<UserProfileResponse>(response);

            return Ok(userProfile);
        }
    }
}
