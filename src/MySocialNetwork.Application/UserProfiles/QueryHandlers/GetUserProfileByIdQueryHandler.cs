using MediatR;
using Microsoft.EntityFrameworkCore;
using MySocialNetwork.Application.UserProfiles.Queries;
using MySocialNetwork.Domain.Aggregates.UserProfileAggregate;
using MySocialNetwork.Infraestructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Application.UserProfiles.QueryHandlers
{
    internal class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, UserProfile>
    {
        private readonly DataContext _dataContext;
        public GetUserProfileByIdQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<UserProfile> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
            => await _dataContext.UserProfiles.FirstOrDefaultAsync(x => x.Id == request.UserId);
    }
}
