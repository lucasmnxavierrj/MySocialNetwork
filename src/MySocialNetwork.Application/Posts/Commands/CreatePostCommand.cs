using MediatR;
using MySocialNetwork.Application.Models;
using MySocialNetwork.Domain.Aggregates.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Application.Posts.Commands
{
    public class CreatePostCommand : IRequest<ProcessResult<Post>>
    {
        public Guid UserProfileId { get; set; }
        public string TextContent { get; set; }
    }
}
