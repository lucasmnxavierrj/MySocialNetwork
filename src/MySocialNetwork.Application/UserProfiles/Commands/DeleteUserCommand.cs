using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Application.UserProfiles.Commands
{
    public class DeleteUserCommand : IRequest<Unit>
    {
        public DeleteUserCommand(string id)
        {
            //TODO: Add validation
            UserId = Guid.Parse(id);
        }
        public Guid UserId { get; set; }
    }
}
