using System.ComponentModel.DataAnnotations;

namespace MySocialNetwork.Api.Contracts.UserProfiles.Requests
{
    public record UserProfileCreate
    (
        string FirstName,
        string LastName,
        string EmailAddress,
        string Phone,
        DateTime DateOfBirth,
        string CurrentCity
    );
}
