using MediatR;
using MySocialNetwork.Application.Models;
using MySocialNetwork.Domain.Aggregates.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Application.Posts.Commands
{
    public class DeletePostCommand : IRequest<ProcessResult<Post>>
    {
        public DeletePostCommand(Guid id)
        {
            Id = id;
        }
        public Guid Id { get; set; }
    }
}
