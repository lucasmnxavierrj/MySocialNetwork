using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MySocialNetwork.Api.Contracts.Posts.Requests;
using MySocialNetwork.Api.Contracts.Posts.Responses;
using MySocialNetwork.Api.Contracts.UserProfiles.Responses;
using MySocialNetwork.Api.Filters;
using MySocialNetwork.Application.Posts.Commands;
using MySocialNetwork.Application.Posts.Queries;
using MySocialNetwork.Application.UserProfiles.Commands;
using MySocialNetwork.Domain.Aggregates.PostAggregate;

namespace MySocialNetwork.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseUrl)]
    [ApiController]
    public class PostsController : BaseController
    {
        [HttpGet("GetAllPosts")]
        public async Task<IActionResult> GetAllPosts(CancellationToken cancellationToken)
        {
            var query = new GetAllPostsQuery();

            var result = await _mediator.Send(query, cancellationToken);

            var response = _mapper.Map<List<PostResponse>>(result.Payload);

            return Ok(response);
        }

        [HttpGet("{id}")]
        [ValidateGuid("id")]
        public async Task<IActionResult> GetById([FromQuery] string id, CancellationToken cancellationToken)
        {
            var query = new GetPostByIdQuery(Guid.Parse(id));

            var result = await _mediator.Send(query, cancellationToken);

            if (result.IsError)
                HandleErrorResponse(result.Errors);

            var response = _mapper.Map<PostResponse>(result.Payload);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePost([FromBody] CreatePost request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<CreatePostCommand>(request);

            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsError)
                HandleErrorResponse(result.Errors);

            var response = _mapper.Map<PostResponse>(result.Payload);

            return CreatedAtAction(nameof(GetById), new { id = result.Payload.Id }, response);
        }

        [HttpPatch]
        public async Task<IActionResult> UpdatePost([FromBody] UpdatePost request, CancellationToken cancellationToken)
        {
            var command = _mapper.Map<UpdatePostCommand>(request);

            var result = await _mediator.Send(command, cancellationToken);

            if (result.IsError)
                HandleErrorResponse(result.Errors);

            return NoContent();
        }

        [HttpDelete]
        [ValidateGuid("id")]
        public async Task<IActionResult> DeletePost([FromQuery] string id, CancellationToken cancellationToken)
        {
            var query = new DeletePostCommand(Guid.Parse(id));

            var response = await _mediator.Send(query, cancellationToken);

            return response.IsError ?
                HandleErrorResponse(response.Errors) :
                NoContent();
        }
    }
}
