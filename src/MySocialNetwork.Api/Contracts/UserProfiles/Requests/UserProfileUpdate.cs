namespace MySocialNetwork.Api.Contracts.UserProfiles.Requests
{
    public record UserProfileUpdate
    (
        Guid Id,
        string FirstName,
        string LastName,
        string EmailAddress,
        string Phone,
        DateTime DateOfBirth,
        string CurrentCity
    );

}
