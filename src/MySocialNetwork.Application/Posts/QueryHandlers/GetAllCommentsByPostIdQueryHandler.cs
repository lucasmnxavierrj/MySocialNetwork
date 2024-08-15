using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MySocialNetwork.Application.Enums;
using MySocialNetwork.Application.Models;
using MySocialNetwork.Application.Posts.Queries;
using MySocialNetwork.Domain.Aggregates.PostAggregate;
using MySocialNetwork.Infraestructure.DataAccess;

namespace MySocialNetwork.Application.Posts.QueryHandlers
{
    public class GetAllCommentsByPostIdQueryHandler : IRequestHandler<GetAllCommentsByPostIdQuery, ProcessResult<List<PostComment>>>
    {
        private readonly DataContext _context;
        public GetAllCommentsByPostIdQueryHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<ProcessResult<List<PostComment>>> Handle(GetAllCommentsByPostIdQuery query, CancellationToken cancellationToken)
        {
            var response = new ProcessResult<List<PostComment>>();

            var post = await _context.Posts
                .Include(x => x.Comments)
                .FirstOrDefaultAsync();

            if (post == null)
            {
                response.IsError = true;
                response.Errors.Add(new(ErrorCode.NotFound, $"Post not found with the id: '{query.PostId}'."));

                return response;
            }

            response.Payload = post.Comments.ToList();

            return response;
        }
    }
}
