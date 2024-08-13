namespace MySocialNetwork.Api.Contracts.Posts.Requests
{
    public record UpdatePost(
        string Id,
        string UerProfileId,
        string TextContent
        );
}
