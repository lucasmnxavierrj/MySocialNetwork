using AutoMapper;
using MediatR;
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
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserProfile>
    {
        private readonly DataContext _context;

        public CreateUserCommandHandler(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
        }
        public async Task<UserProfile> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // TODO: Adicionar Validação
            var basicInfo = BasicInfo.CreateBasicInfo(request.FirstName, request.LastName,
                request.EmailAddress, request.Phone, request.DateOfBirth, request.CurrentCity);

            var userProfile = UserProfile.CreateUserProfile(Guid.NewGuid().ToString(), basicInfo);

            _context.UserProfiles.Add(userProfile);

            await _context.SaveChangesAsync();

            return userProfile;
        }
    }
}
