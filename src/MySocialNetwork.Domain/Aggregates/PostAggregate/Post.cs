using MySocialNetwork.Domain.Exceptions;
using MySocialNetwork.Domain.Validators.PostValidators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Aggregates.PostAggregate
{
    public class Post
    {
        private readonly List<PostComment> _comments = new();
        private readonly List<PostInteraction> _interactions = new();

        private Post()
        {
        }
        public Guid Id { get; private set; }
        public Guid UserProfileId { get; private set; }
        public string TextContent { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastModified { get; private set; }
        public IEnumerable<PostComment> Comments { get { return _comments; } }
        public IEnumerable<PostInteraction> Interactions { get { return _interactions; } }

        #region Factory Methods
        public static Post CreatePost(Guid userProfileId, string textContent)
        {
            var postValidator = new PostValidator();

            var objectToValidate = new Post()
            {
                UserProfileId = userProfileId,
                TextContent = textContent,
                CreatedDate = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
            };

            var validationResult = postValidator.Validate(objectToValidate);

            if (validationResult.IsValid)
                return objectToValidate;

            throw new DomainValidationException(
                "Error validating the creation of Post.",
                validationResult.Errors.Select(error => error.ErrorMessage).ToList());
        }
        #endregion
        #region Public Methods
        public void UpdatePostText(string newText)
        {
            if(string.IsNullOrEmpty(newText) is true)
                throw new DomainValidationException("The Post's new text cannot be null or empty.");

            TextContent = newText;
            LastModified = DateTime.UtcNow;
        }

        public void AddPostComment(PostComment postComment)
        {
            _comments.Add(postComment);
        }
        public void AddPostInteraction(PostInteraction postInteraction)
        {
            _interactions.Add(postInteraction);
        }
        public void RemovePostComment(PostComment postComment)
        {
            _comments.Remove(postComment);
        }
        public void RemovePostInteraction(PostInteraction postInteraction)
        {
            _interactions.Remove(postInteraction);
        }
        #endregion
    }
}
