using MediatR;
using MySocialNetwork.Application.Enums;
using MySocialNetwork.Application.Models;
using MySocialNetwork.Application.Posts.Commands;
using MySocialNetwork.Domain.Aggregates.PostAggregate;
using MySocialNetwork.Infraestructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Application.Posts.CommandHandlers
{
    internal class CreatePostCommentCommandHandler : IRequestHandler<CreatePostCommentCommand, ProcessResult<PostComment>>
    {
        private readonly DataContext _context;
        public CreatePostCommentCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<ProcessResult<PostComment>> Handle(CreatePostCommentCommand command, CancellationToken cancellationToken)
        {
            var result = new ProcessResult<PostComment>();

            try
            {
                var post = PostComment
                    .CreatePostComment(command.PostId, command.UserProfileId, command.Text);

                await _context.AddAsync(post);

                result.Payload = post;

                return result;
            }
            catch (Exception ex)
            {
                result.IsError = true;

                result.Errors.Add(new()
                {
                    Code = ErrorCode.ServerError,
                    Message = ex.Message,
                });

                return result;
            }

        }
    }
}
