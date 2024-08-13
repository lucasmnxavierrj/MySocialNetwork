using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, ProcessResult<Post>>
    {
        private readonly DataContext _context;
        public UpdatePostCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<ProcessResult<Post>> Handle(UpdatePostCommand command, CancellationToken cancellationToken)
        {
            var result = new ProcessResult<Post>();

            try
            {
                var post = await _context.Posts.FirstOrDefaultAsync(x => x.Id == command.Id);

                if (post is null)
                {
                    result.IsError = true;
                    result.Errors.Add(new(ErrorCode.BadRequest, $"Post not found with specified id: {command.Id}"));

                    return result;
                }

                post.UpdatePostText(command.TextContent);

                await _context.SaveChangesAsync(cancellationToken);

                result.Payload = post;

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
