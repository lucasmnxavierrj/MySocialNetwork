namespace MySocialNetwork.Api.Contracts.Posts.Requests
{
    public record AddCommentToPost(
        string UserProfileId,
        string Text
        );
}
