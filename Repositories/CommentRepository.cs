using System.Collections.Generic;
using CommentNET.Data;

namespace CommentNET.Models
{
    public interface ICommentRepository
    {
        IEnumerable<CommentDTO> CommentDTOs { get; }
    }

    public class CommentRepository //: ICommentRepository 
    {
        private CommentsContext _context;
        public CommentRepository(CommentsContext context)
        {
            _context = context;
        }
        public IEnumerable<CommentDTO> CommentDTOs() {
            var commentDTOs= new List<CommentDTO>();
            return commentDTOs;
        }
            // var allComments = _context.Comments
            //     .Where(c => c.ContentId == contentId)
            //     .AsNoTracking();

        // IEnumerable<Comment> mainComments = _context.Comments
        //     .Where(c => c.ContentId == contentId)
        //     .Where(c => c.ParentId == null)
        //     .OrderBy(c => c.PostDate)
        //     .AsNoTracking();

        // foreach (var comment in mainComments)
        // {
        //     var subComments = _context.Comments
        //         .Where(c => c.ContentId == contentId)
        //         .Where(c => c.ParentId == comment.Id)
        //         .OrderBy(c => c.PostDate)
        //         .AsNoTracking();

        //     commentDTOs.Add(
        //         new CommentDTO(){ 
        //             MainComment = comment, 
        //             SubComments = subComments 
        //             }
        //     );
        // }
    }
}