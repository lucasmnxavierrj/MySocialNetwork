using MediatR;
using Microsoft.EntityFrameworkCore;
using MySocialNetwork.Application.UserProfiles.Commands;
using MySocialNetwork.Infraestructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Application.UserProfiles.CommandHandlers
{
    internal class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private readonly DataContext _context;
        public DeleteUserCommandHandler(DataContext dataContext)
        {
            _context = dataContext;
        }
        public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var userProfile = await _context.UserProfiles
                .FirstOrDefaultAsync(x => x.Id == request.UserId);

            _context.Remove(userProfile);

            await _context.SaveChangesAsync();

            return new Unit();
        }
    }
}
