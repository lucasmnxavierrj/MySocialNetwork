using System.Globalization;

namespace MySocialNetwork.Api.Contracts.Posts.Responses
{
    public record PostResponse(
        Guid Id,
        Guid UserProfileId,
        string TextContent,
        DateTime CreatedDate,
        DateTime LastModified);
}
