using FluentValidation;
using MySocialNetwork.Domain.Aggregates.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Validators.PostValidators
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(post => post.TextContent)
                .NotEmpty().WithMessage("Post content cannot be empty.")
                .NotNull().WithMessage("Post content cannot be null.");
        }
    }
}
