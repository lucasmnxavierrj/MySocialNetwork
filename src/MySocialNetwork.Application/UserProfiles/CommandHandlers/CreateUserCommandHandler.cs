using AutoMapper;
using MediatR;
using MySocialNetwork.Application.Enums;
using MySocialNetwork.Application.Models;
using MySocialNetwork.Application.UserProfiles.Commands;
using MySocialNetwork.Domain.Aggregates.UserProfileAggregate;
using MySocialNetwork.Domain.Exceptions;
using MySocialNetwork.Infraestructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Application.UserProfiles.CommandHandlers
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, ProcessResult<UserProfile>>
    {
        private readonly DataContext _context;

        public CreateUserCommandHandler(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
        }
        public async Task<ProcessResult<UserProfile>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var result = new ProcessResult<UserProfile>();

            try
            {
                var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName,
                    request.EmailAddress, request.Phone, request.DateOfBirth, request.CurrentCity);

                var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), basicInfo);

                _context.UserProfiles.Add(userProfile);

                await _context.SaveChangesAsync();

                result.Payload = userProfile;

                return result;
            }
            catch(DomainValidationException ex)
            {
                result.IsError = true;

                result.Errors = ex.ValidationErrors
                    .Select(error => new Error(ErrorCode.BadRequest, error))
                    .ToList();

                return result;
            }
            catch (Exception ex)
            {
                result.IsError = true;

                result.Errors = [new(ErrorCode.ServerError, ex.Message)];

                return result;
            }
        }
    }
}
