﻿using MediatR;
using MySocialNetwork.Application.Models;
using MySocialNetwork.Domain.Aggregates.UserProfileAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Application.UserProfiles.Queries
{
    public class GetAllUserProfilesQuery : IRequest<ProcessResult<IEnumerable<UserProfile>>>
    {
    }
}
