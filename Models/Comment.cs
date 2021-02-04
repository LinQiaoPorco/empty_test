using System;

namespace CommentNET.Models
{
    public class Comment
    {
        public long Id { get; set; }
        public DateTime PostDate { get; set; }
        public string CommentContent { get; set; }
        public string ContentId { get; set; }
        public string CommentedUserName { get; set; }
        public string CommentedUserId { get; set; }
        public bool Hidden { get; set; }
        public int CommentLiked { get; set; }
        public int CommentDisliked { get; set; }
        public long? ParentId { get; set; }
        //public virtual Comment Parent { get; set; }
        //public virtual ICollection<Comment> ChildrenComments { get; set; }

    }
}