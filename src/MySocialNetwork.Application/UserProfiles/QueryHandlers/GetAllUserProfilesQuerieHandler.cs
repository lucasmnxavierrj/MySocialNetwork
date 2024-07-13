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
    internal class GetAllUserProfilesQuerieHandler : IRequestHandler<GetAllUserProfilesQuery, IEnumerable<UserProfile>>
    {
        private readonly DataContext _context;
        public GetAllUserProfilesQuerieHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserProfile>> Handle(GetAllUserProfilesQuery request, CancellationToken cancellationToken)
            => await _context.UserProfiles.AsNoTracking().ToListAsync(cancellationToken);
    }
}
