using CommentNET.Models;
using Microsoft.EntityFrameworkCore;

namespace CommentNET.Data
{
    public class CommentsContext : DbContext
    {
        public CommentsContext(DbContextOptions<CommentsContext> options) : base(options)
        {}
        public DbSet<Comment> Comments { get; set;}
    }
}