namespace MySocialNetwork.Api.Contracts.Posts.Requests
{
    public record CreatePostComment(
        string UserProfileId,
        string Text
        );
}
