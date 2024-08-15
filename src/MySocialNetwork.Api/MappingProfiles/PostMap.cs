using AutoMapper;
using MySocialNetwork.Api.Contracts.Posts.Requests;
using MySocialNetwork.Api.Contracts.Posts.Responses;
using MySocialNetwork.Application.Posts.Commands;
using MySocialNetwork.Application.UserProfiles.Commands;
using MySocialNetwork.Domain.Aggregates.PostAggregate;

namespace MySocialNetwork.Api.MappingProfiles
{
    public class PostMap : Profile
    {
        public PostMap()
        {
            CreateMap<CreatePost, CreatePostCommand>()
                .ForMember(dest => dest.UserProfileId,
                    opt => opt.MapFrom(src => Guid.Parse(src.UerProfileId)));
            CreateMap<UpdatePost, UpdatePostCommand>()
                .ForMember(dest => dest.UserProfileId,
                    opt => opt.MapFrom(src => Guid.Parse(src.UserProfileId)));
            CreateMap<Post, PostResponse>();
            CreateMap<PostCommentResponse, PostComment>();
            CreateMap<AddCommentToPost, AddCommentToPostCommand>()
                .ForMember(dest => dest.UserProfileId,
                    opt => opt.MapFrom(src => Guid.Parse(src.UserProfileId)));
        }
    }
}
