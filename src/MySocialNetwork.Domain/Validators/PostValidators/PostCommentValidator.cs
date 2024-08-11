using FluentValidation;
using MySocialNetwork.Domain.Aggregates.PostAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Validators.PostValidators
{
    public class PostCommentValidator : AbstractValidator<PostComment>
    {
        public PostCommentValidator()
        {
            RuleFor(postComment => postComment.Text)
                .NotNull().WithMessage("Comment text should not be null")
                .NotEmpty().WithMessage("Comment text should not be empty")
                .MaximumLength(1000)
                .MinimumLength(1);
        }
    }
}
