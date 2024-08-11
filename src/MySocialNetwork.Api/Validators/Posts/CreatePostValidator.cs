using FluentValidation;
using MySocialNetwork.Api.Contracts.Posts.Requests;
using MySocialNetwork.Api.Filters;

namespace MySocialNetwork.Api.Validators.Posts
{
    public class CreatePostValidator : AbstractValidator<CreatePost>
    {
        public CreatePostValidator()
        {
            RuleFor(x => x.UerProfileId)
                .NotNull()
                .NotEmpty()
                .Must(x => Guid.TryParse(x, out var _)).WithMessage("Not a valid Guid.");
        }
    }
}
