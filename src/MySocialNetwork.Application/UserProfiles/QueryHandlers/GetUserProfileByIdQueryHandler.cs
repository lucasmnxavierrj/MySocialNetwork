using MediatR;
using Microsoft.EntityFrameworkCore;
using MySocialNetwork.Application.Enums;
using MySocialNetwork.Application.Models;
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
    internal class GetUserProfileByIdQueryHandler : IRequestHandler<GetUserProfileByIdQuery, ProcessResult<UserProfile>>
    {
        private readonly DataContext _dataContext;
        public GetUserProfileByIdQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<ProcessResult<UserProfile>> Handle(GetUserProfileByIdQuery request, CancellationToken cancellationToken)
        {
            var result = new ProcessResult<UserProfile>();

            var userProfile = await _dataContext.UserProfiles
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (userProfile == null)
            {
                result.IsError = true;

                result.Errors.Add(new()
                {
                    Code = ErrorCode.NotFound,
                    Message = $"User not found with the id: '{request.Id}'.",
                });

                return result;
            }

            result.Payload = userProfile;

            return result;
        }
    }
}
