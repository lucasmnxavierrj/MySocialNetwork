using MediatR;
using MySocialNetwork.Application.Models;
using MySocialNetwork.Domain.Aggregates.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Application.Posts.Queries
{
    public class GetAllCommentsByPostIdQuery : IRequest<ProcessResult<List<PostComment>>>
    {
        public GetAllCommentsByPostIdQuery(Guid postId)
        {
            PostId = postId;
        }
        public Guid PostId { get; set; }
    }
}
