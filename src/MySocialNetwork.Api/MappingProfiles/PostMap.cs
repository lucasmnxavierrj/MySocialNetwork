﻿using AutoMapper;
using MySocialNetwork.Api.Contracts.Posts.Requests;
using MySocialNetwork.Api.Contracts.Posts.Responses;
using MySocialNetwork.Application.Posts.Commands;
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
            CreateMap<Post, PostResponse>();

        }
    }
}