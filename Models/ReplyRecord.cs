using System;

namespace CommentNET.Models
{
    public class ReplyRecord
    {
        public long Id { get; set;}
        public DateTime dateTime { get; set;}
        public string ContentId { get; set;}
        public string CommentedBy { get; set;}
        

    }
}