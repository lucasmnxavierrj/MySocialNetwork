using MySocialNetwork.Domain.Aggregates.UserProfileAggregate;

namespace MySocialNetwork.Api.Contracts.UserProfiles.Responses
{
    public record UserProfileResponse
    {
        public string IdentityId { get; set; }
        public BasicInfoDTO BasicInfo { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime LastModified { get; set; }
    }
}
