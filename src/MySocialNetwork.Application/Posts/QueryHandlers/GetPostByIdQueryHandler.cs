using MediatR;
using Microsoft.EntityFrameworkCore;
using MySocialNetwork.Application.Enums;
using MySocialNetwork.Application.Models;
using MySocialNetwork.Application.Posts.Queries;
using MySocialNetwork.Domain.Aggregates.PostAggregate;
using MySocialNetwork.Infraestructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Application.Posts.QueryHandlers
{
    public class GetPostByIdQueryHandler : IRequestHandler<GetPostByIdQuery, ProcessResult<Post>>
    {
        private readonly DataContext _context;
        public GetPostByIdQueryHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<ProcessResult<Post>> Handle(GetPostByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new ProcessResult<Post>();

            var result = await _context.Posts.FirstOrDefaultAsync(post => post.Id == request.Id, cancellationToken);

            if (result is not null)
            {
                response.Payload = result;

                return response;
            }

            response.IsError = true;
            response.Errors.Add(new()
            {
                Code = ErrorCode.NotFound,
                Message = $"User not found with the id: '{request.Id}'.",
            });

            return response;
        }
    }
}
