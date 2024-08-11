using MediatR;
using MySocialNetwork.Application.Enums;
using MySocialNetwork.Application.Models;
using MySocialNetwork.Application.Posts.Commands;
using MySocialNetwork.Domain.Aggregates.PostAggregate;
using MySocialNetwork.Domain.Exceptions;
using MySocialNetwork.Domain.Validators.PostValidators;
using MySocialNetwork.Infraestructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Application.Posts.CommandHandlers
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, ProcessResult<Post>>
    {
        private readonly DataContext _context;
        public CreatePostCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<ProcessResult<Post>> Handle(CreatePostCommand command, CancellationToken cancellationToken)
        {
            var result = new ProcessResult<Post>();

            try
            {
                result.Payload = Post.CreatePost(command.UserProfileId, command.TextContent);

                _context.Posts.Add(result.Payload);

                await _context.SaveChangesAsync(cancellationToken);

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
            catch(Exception ex)
            {
                result.IsError = true;
                result.Errors.Add(new(ErrorCode.ServerError, ex.Message));

                return result;
            }
        }
    }
}
