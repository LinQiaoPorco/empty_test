using System;

namespace CommentNET.Models
{
    public class Comment
    {
        public long Id { get; set;}
        public DateTime dateTime { get; set;}
        public string ContentId { get; set;}
        public string CommentedBy { get; set;}
        public long ParentId { get; set;}
        public Int64 CommentLiked { get; set;}
        public Int64 CommentDisliked { get; set;}

    }
}