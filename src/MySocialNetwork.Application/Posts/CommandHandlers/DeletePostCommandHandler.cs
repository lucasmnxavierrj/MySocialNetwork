using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
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
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, ProcessResult<Post>>
    {
        private readonly DataContext _context;
        public DeletePostCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<ProcessResult<Post>> Handle(DeletePostCommand command, CancellationToken cancellationToken)
        {
            var response = new ProcessResult<Post>();

            var post = await _context.Posts
                .FirstOrDefaultAsync(x => x.Id == command.Id, cancellationToken);

            if (post is null)
            {
                response.IsError = true;
                response.Errors.Add(new(ErrorCode.NotFound, $"Post not found with the id: '{command.Id}'."));

                return response;
            }

            _context.Remove(post);

            await _context.SaveChangesAsync(cancellationToken);

            return response;
        }
    }
}
