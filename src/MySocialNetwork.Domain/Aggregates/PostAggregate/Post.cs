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
        public Guid PostId { get; private set; }
        public Guid UserProfileId { get; private set; }
        public string TextContent { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime LastModified { get; private set; }
        public IEnumerable<PostComment> Comments { get { return _comments; } }
        public IEnumerable<PostInteraction> Interactions { get { return _interactions; } }

        #region Factory Methods
        public static Post CreatePost(Guid userProfileId, string textContent)
        {
            // Adicionar Lógica

            return new()
            {
                UserProfileId = userProfileId,
                TextContent = textContent,
                CreatedDate = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
            };
        }
        #endregion
        #region Public Methods
        public void UpdatePostText(string newText)
        {
            // Add validation

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
