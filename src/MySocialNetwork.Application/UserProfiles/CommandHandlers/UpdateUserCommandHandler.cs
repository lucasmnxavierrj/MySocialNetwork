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
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, ProcessResult<UserProfile>>
    {
        private readonly DataContext _context;
        public UpdateUserCommandHandler(DataContext context)
        {
            _context = context;
        }
        public async Task<ProcessResult<UserProfile>> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new ProcessResult<UserProfile>();

            try
            {
                var userProfile = await _context.UserProfiles
                    .FirstOrDefaultAsync(x => x.Id == request.Id);

                if(userProfile is null)
                {
                    result.IsError = true;

                    result.Errors.Add(new()
                    {
                        Code = ErrorCode.NotFound,
                        Message = $"User not found with the id: '{request.Id}'.",
                    });

                    return result;
                }

                var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName,
                    request.EmailAddress, request.Phone, request.DateOfBirth, request.CurrentCity);

                userProfile.UpdateBasicInfo(basicInfo);
                await _context.SaveChangesAsync(cancellationToken);

                result.Payload = userProfile;

                return result;
            }
            catch(Exception ex)
            {
                result.IsError = true;

                result.Errors.Add(new()
                {
                    Code = ErrorCode.ServerError,
                    Message = ex.Message,
                });
            }

            return result;
        }
    }
}
