using MediatR;
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
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, ProcessResult<List<Post>>>
    {
        private readonly DataContext _dataContext;
        public GetAllPostsQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ProcessResult<List<Post>>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var result = new ProcessResult<List<Post>>();

            result.Payload = _dataContext.Posts.ToList();

            return result;
        }
    }
}
