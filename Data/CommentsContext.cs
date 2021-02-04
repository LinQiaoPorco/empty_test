using CommentNET.Models;
using Microsoft.EntityFrameworkCore;

namespace CommentNET.Data
{
    public class CommentsContext : DbContext
    {
        public CommentsContext(DbContextOptions<CommentsContext> options) : base(options)
        {}
        public DbSet<Comment> Comments { get; set; }
        // protected override void OnModelCreating(ModelBuilder builder)
        // {
        //     base.OnModelCreating(builder);
        //     //Table Name
        //     builder.Entity<Comment>().ToTable("Comments");

        //     //Primary Key
        //     builder.Entity<Comment>().HasKey(c => c.Id);

        //     //RelationShips
        //      builder.Entity<Comment>().HasMany()

        // }
    }
}