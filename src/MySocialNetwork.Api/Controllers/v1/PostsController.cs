using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using MySocialNetwork.Domain.Aggregates.PostAggregate;

namespace MySocialNetwork.Api.Controllers.v1
{
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok(new Post { Id = id, Text = "Hello world!" });
        }
    }
}
