﻿namespace MySocialNetwork.Api.Contracts.Posts.Requests
{
    public record UpdatePost(
        string UserProfileId,
        string TextContent
        );
}