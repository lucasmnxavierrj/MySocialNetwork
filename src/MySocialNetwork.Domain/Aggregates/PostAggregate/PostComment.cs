using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySocialNetwork.Domain.Aggregates.PostAggregate
{
    public class PostComment
    {
        public Guid CommentId { get; set; }
        public Guid PostId { get; set; }
        public Guid UserProfileId { get; set; }
        public string Text { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? LastModified { get; set; }
    }
}
