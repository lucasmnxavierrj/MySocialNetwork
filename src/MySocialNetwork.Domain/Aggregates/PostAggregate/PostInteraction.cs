using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Aggregates.PostAggregate
{
    public class PostInteraction
    {
        public Guid InteractionId { get; private set; }
        public Guid PostId { get; private set; }
        public InteractionType InteractionType { get; private set; }

        #region Factory Methods
        public static PostInteraction CreatePostInteraction(Guid postId, InteractionType interactionType)
        {
            // TODO: Adicionar validação.

            return new()
            {
                PostId = postId,
                InteractionType = interactionType
            };
        }
        #endregion
    }
}
