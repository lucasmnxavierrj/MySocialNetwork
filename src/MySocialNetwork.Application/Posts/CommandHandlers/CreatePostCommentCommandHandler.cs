using MediatR;
using MySocialNetwork.Application.Enums;
using MySocialNetwork.Application.Models;
using MySocialNetwork.Application.Posts.Commands;
using MySocialNetwork.Domain.Aggregates.PostAggregate;
using MySocialNetwork.Domain.Exceptions;
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
                var comment = PostComment
                    .CreatePostComment(command.PostId, command.UserProfileId, command.Text);

                await _context.AddAsync(comment);

                result.Payload = comment;

                return result;
            }
            catch(DomainValidationException ex)
            {
                result.IsError = true;

                result.Errors = ex.ValidationErrors
                    .Select(error => new Error(ErrorCode.BadRequest, error))
                    .ToList();

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
