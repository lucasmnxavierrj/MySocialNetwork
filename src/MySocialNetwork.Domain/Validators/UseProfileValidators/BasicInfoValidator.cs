﻿using FluentValidation;
using MySocialNetwork.Domain.Aggregates.UserProfileAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Validators.UseProfileValidators
{
    public class BasicInfoValidator : AbstractValidator<BasicInfo>
    {
        public BasicInfoValidator()
        {
            RuleFor(info => info.FirstName)
                .NotNull().WithMessage("First name is required.")
                .MinimumLength(3).WithMessage("First name must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("First name can contain at most 50 characters long.");

            RuleFor(info => info.LastName)
                .NotNull().WithMessage("Last name is required.")
                .MinimumLength(3).WithMessage("Last name must be at least 3 characters long.")
                .MaximumLength(50).WithMessage("Last name can contain at most 50 characters long.");

            RuleFor(info => info.EmailAddress)
                .NotNull().WithMessage("Email address is required.")
                .EmailAddress().WithMessage("Provided string is not a correct email address format.");

            RuleFor(info => info.DateOfBirth)
                .InclusiveBetween(
                    new DateTime(DateTime.Now.AddYears(-125).Ticks),
                    new DateTime(DateTime.Now.AddYears(-18).Ticks))
                .WithMessage("Age needs to be between 18 and 125.");
        }
    }
}
