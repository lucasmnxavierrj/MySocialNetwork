using Asp.Versioning;
using AutoMapper;
using Azure;
using Azure.Core;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MySocialNetwork.Api.Contracts.UserProfiles.Requests;
using MySocialNetwork.Api.Contracts.UserProfiles.Responses;
using MySocialNetwork.Api.Filters;
using MySocialNetwork.Api.Validators.UserProfile;
using MySocialNetwork.Application.Enums;
using MySocialNetwork.Application.UserProfiles.Commands;
using MySocialNetwork.Application.UserProfiles.Queries;
using System.Collections.Generic;

namespace MySocialNetwork.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [ApiController]
    [Route(ApiRoutes.BaseUrl)]
    public class UserProfilesController : BaseController
    {

        [HttpGet("GetAllProfiles")]
        public async Task<IActionResult> GetAllProfiles(CancellationToken cancellationToken)
        {
            var query = new GetAllUserProfilesQuery();

            var response = await _mediator.Send(query, cancellationToken);

            var userProfiles = _mapper.Map<List<UserProfileResponse>>(response.Payload);

            return Ok(userProfiles);
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserProfileAsync([FromBody] UserProfileCreate request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreateUserCommand>(request);

            var response = await _mediator.Send(command, cancellationToken);

            if (response.IsError)
                HandleErrorResponse(response.Errors);

            var userProfileResponse = _mapper.Map<UserProfileResponse>(response.Payload);

            return CreatedAtAction(nameof(GetUserProfileById), new { id = response.Payload.Id }, userProfileResponse);
        }

        [HttpGet("{id}")]
        [ValidateGuid("id")]
        public async Task<IActionResult> GetUserProfileById(string id, CancellationToken cancellationToken)
        {
            var query = new GetUserProfileByIdQuery(Guid.Parse(id));

            var response = await _mediator.Send(query, cancellationToken);

            if (response.IsError) 
                HandleErrorResponse(response.Errors);

            var userProfile = _mapper.Map<UserProfileResponse>(response.Payload);

            return Ok(userProfile);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdateUserProfile(UserProfileUpdate request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdateUserCommand>(request);

            var response = await _mediator.Send(command, cancellationToken);

            return response.IsError ?
                HandleErrorResponse(response.Errors) :
                NoContent();
        }

        [HttpDelete]
        [ValidateGuid("id")]
        public async Task<IActionResult> DeleteUserProfile(string id, CancellationToken cancellationToken)
        {
            var query = new DeleteUserCommand(Guid.Parse(id));

            var response = await _mediator.Send(query);

            return response.IsError ?
                HandleErrorResponse(response.Errors) :
                NoContent();
        }
    }
}
