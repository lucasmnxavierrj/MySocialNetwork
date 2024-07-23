using MediatR;
using MySocialNetwork.Application.Models;
using MySocialNetwork.Domain.Aggregates.UserProfileAggregate;


namespace MySocialNetwork.Application.UserProfiles.Commands
{
    public class UpdateUserCommand : IRequest<ProcessResult<UserProfile>>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; } // Talvez transformar em Value Object
        public string Phone { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string CurrentCity { get; set; }
    }
}
