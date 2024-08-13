using MediatR;
using Microsoft.EntityFrameworkCore;
using MySocialNetwork.Application.Enums;
using MySocialNetwork.Application.Models;
using MySocialNetwork.Application.UserProfiles.Commands;
using MySocialNetwork.Domain.Aggregates.UserProfileAggregate;
using MySocialNetwork.Infraestructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Application.UserProfiles.CommandHandlers
{
    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, ProcessResult<UserProfile>>
    {
        private readonly DataContext _context;
        public DeleteUserCommandHandler(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<ProcessResult<UserProfile>> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var result = new ProcessResult<UserProfile>();

            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(x => x.Id == command.Id);

            if(userProfile == null)
            {
                result.IsError = true;

                result.Errors.Add(new()
                {
                    Code = ErrorCode.NotFound,
                    Message = $"User not found with the id: '{command.Id}'.",
                });

                return result;
            }

            _context.Remove(userProfile);

            await _context.SaveChangesAsync();

            return result;
        }
    }
}
