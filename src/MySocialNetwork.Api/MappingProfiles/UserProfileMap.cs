using AutoMapper;
using MySocialNetwork.Api.Contracts.Posts.Responses;
using MySocialNetwork.Api.Contracts.UserProfiles.Requests;
using MySocialNetwork.Api.Contracts.UserProfiles.Responses;
using MySocialNetwork.Application.UserProfiles.Commands;
using MySocialNetwork.Domain.Aggregates.PostAggregate;
using MySocialNetwork.Domain.Aggregates.UserProfileAggregate;

namespace MySocialNetwork.Api.MappingProfiles
{
    public class UserProfileMap : Profile
    {
        public UserProfileMap()
        {
            CreateMap<CreateUserCommand, BasicInfo>();
            CreateMap<UserProfileCreate,CreateUserCommand>();
            CreateMap<UserProfile, UserProfileResponse>();
            CreateMap<BasicInfo, BasicInformation>();
            CreateMap<UserProfileUpdate, UpdateUserCommand>();
            CreateMap<Post, PostResponse>();
        }
    }
}
