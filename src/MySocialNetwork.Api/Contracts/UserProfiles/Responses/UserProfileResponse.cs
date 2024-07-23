using MySocialNetwork.Domain.Aggregates.UserProfileAggregate;

namespace MySocialNetwork.Api.Contracts.UserProfiles.Responses
{
    public record UserProfileResponse
    {
        public string Id { get; set; }
        public BasicInformation BasicInfo { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}
