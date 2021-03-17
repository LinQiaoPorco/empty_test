using System;

namespace CommentNET.Models
{
    public class CommentPost
    {
        public string CommentContent { get; set; }
        public string ContentId { get; set; }
        public string CommentedUserName { get; set; }
        public string CommentedUserId { get; set; }
        public long? ParentId { get; set; }
        //public virtual Comment Parent { get; set; }
        //public virtual ICollection<Comment> ChildrenComments { get; set; }

    }
}