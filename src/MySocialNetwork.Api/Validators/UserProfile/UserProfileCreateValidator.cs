﻿using FluentValidation;
using MySocialNetwork.Api.Contracts.UserProfiles.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Api.Validators.UserProfile
{
    public class UserProfileCreateValidator : AbstractValidator<UserProfileCreate>
    {
        public UserProfileCreateValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(30);

            RuleFor(x => x.LastName)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(60);

            RuleFor(x => x.EmailAddress)
                .NotEmpty()
                .NotNull()
                .EmailAddress();

            RuleFor(x => x.DateOfBirth)
                .NotEmpty()
                .NotNull()
                .NotEqual(default(DateTime));
        }
    }
}
