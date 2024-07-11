using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MySocialNetwork.Domain.Aggregates.PostAggregate;

namespace MySocialNetwork.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route(ApiRoutes.BaseUrl)]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok("Hello World");
        }
    }
}
