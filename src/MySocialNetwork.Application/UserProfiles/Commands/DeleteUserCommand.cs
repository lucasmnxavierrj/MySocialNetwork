using MediatR;
using MySocialNetwork.Application.Models;
using MySocialNetwork.Domain.Aggregates.UserProfileAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Application.UserProfiles.Commands
{
    public class DeleteUserCommand : IRequest<ProcessResult<UserProfile>>
    {
        public DeleteUserCommand(string id)
        {
            if (Guid.TryParse(id, out Guid userId) is false)
                return;

            UserId = userId;
        }
        public Guid UserId { get; set; }
    }
}
