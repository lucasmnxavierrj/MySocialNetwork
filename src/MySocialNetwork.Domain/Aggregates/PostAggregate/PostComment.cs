using MySocialNetwork.Domain.Exceptions;
using MySocialNetwork.Domain.Validators.PostValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Aggregates.PostAggregate
{
    public class PostComment
    {
        private PostComment()
        {
            
        }
        public Guid Id { get; private set; }
        public Guid PostId { get; private set; }
        public Guid UserProfileId { get; private set; }
        public string Text { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? LastModified { get; private set; }

        #region Factory Methods
        public static PostComment CreatePostComment(Guid postId, Guid userProfileId, string text)
        {
            var validator = new PostCommentValidator();

            var objectToValidate = new PostComment()
            {
                PostId = postId,
                UserProfileId = userProfileId,
                Text = text,
                CreatedDate = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
            };

            var validationResult = validator.Validate(objectToValidate);

            if (validationResult.IsValid)
                return objectToValidate;

            throw new DomainValidationException(
                "Error validating the creation of PostComment.",
                validationResult.Errors.Select(error => error.ErrorMessage).ToList());
        }
        #endregion
        #region Public Methods
        public void UpdateCommentText(string newText)
        {
            if (string.IsNullOrEmpty(newText) is true)
                throw new DomainValidationException("The PostComment's new text cannot be null or empty.");

            Text = newText;
            LastModified = DateTime.UtcNow;
        }
        #endregion
    }
}
