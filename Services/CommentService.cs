using CommentNET.Models;
using CommentNET.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CommentNET.Services
{
    public interface ICommentService
    {
        Task<IEnumerable<Comment>> ListAsync();
    }

    // public class CommentService : ICommentService
    // {
    //     private readonly CommentsContext _context;

    //     public CommentService(CommentsContext context)
    //     {
    //         _context = context;
    //     } 
    //     public async Task<IEnumerable<Comment>> ListAsnyc()
    //     {
    //         return _context.Comments.;
    //     }
    // }

}