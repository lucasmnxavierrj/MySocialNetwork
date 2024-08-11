namespace MySocialNetwork.Api.Contracts.Posts.Requests
{
    public record CreatePost(
        string UerProfileId,
        string TextContent
        );
}
