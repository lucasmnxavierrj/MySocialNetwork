using FluentValidation;
using MySocialNetwork.Api.Contracts.Posts.Requests;
using MySocialNetwork.Api.Filters;

namespace MySocialNetwork.Api.Validators.Posts
{
    public class AddCommentToPostValidator : AbstractValidator<CreatePostComment>
    {
        public AddCommentToPostValidator()
        {
            RuleFor(x => x.UserProfileId)
                .NotNull()
                .NotEmpty()
                .Must(x => Guid.TryParse(x, out var _)).WithMessage("Not a valid Guid.");

            RuleFor(x => x.Text)
                .NotNull()
                .NotEmpty();
        }
    }
}
