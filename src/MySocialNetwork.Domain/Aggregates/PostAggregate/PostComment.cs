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
        public Guid CommentId { get; private set; }
        public Guid PostId { get; private set; }
        public Guid UserProfileId { get; private set; }
        public string Text { get; private set; }
        public DateTime CreatedDate { get; private set; }
        public DateTime? LastModified { get; private set; }

        #region Factory Methods
        public static PostComment CreatePostComment(Guid postId, Guid userProfileId, string text)
        {
            // TODO: Adicionar validação

            return new()
            {
                PostId = postId,
                UserProfileId = userProfileId,
                Text = text,
                CreatedDate = DateTime.UtcNow,
                LastModified = DateTime.UtcNow,
            };
        }
        #endregion
        #region Public Methods
        public void UpdateCommentText(string newText)
        {
            Text = newText;
            LastModified = DateTime.UtcNow;
        }
        #endregion
    }
}
