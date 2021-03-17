using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using CommentNET.Data;
using CommentNET.Models;
using CommentNET.Services;

namespace CommentNET.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class CommentsController : ControllerBase
    {
        private CommentsContext _context;
        public CommentsController(CommentsContext context)
        {
            _context = context;
        }
        // private readonly ICommentService _commentService;
        
        // public CommentsController(ICommentService commentService)
        // {
        //     _commentService = commentService;   
        // }

        // GET: api/Comments
        //[HttpGet]
        // public async Task<IEnumerable<Comment>> GetComments()
        // {
        //     var comments = await _commentService.ListAsync();
        //     return comments;
        // }
        
        [HttpGet]
        public IEnumerable<Comment> GetComments()
        {
            Console.WriteLine("====================");
            foreach (var c in User.Claims)
            {
                Console.WriteLine("{0} ==> {1}", c.Type, c.Value);
            }
            
            return _context.Comments.AsNoTracking();
        }

        //[Route("api/content/[controller]/{contentId}")]
        [HttpGet("{contentId}")]
        public IEnumerable<CommentDTO> GetCommentsByContentId(string contentId)
        {
            Console.WriteLine(HttpContext.User.Identity);
            var commentDTOs = new List<CommentDTO>();
            // var allComments = _context.Comments
            //     .Where(c => c.ContentId == contentId)
            //     .AsNoTracking();

            var mainComments = _context.Comments
                .Where(c => c.ContentId == contentId)
                .Where(c => c.ParentId == null)
                .OrderBy(c => c.PostDate)
                .AsNoTracking();

            foreach (var comment in mainComments)
            {
                var subComments = _context.Comments
                    .Where(c => c.ContentId == contentId)
                    .Where(c => c.ParentId == comment.Id)
                    .OrderBy(c => c.PostDate)
                    .AsNoTracking();

                commentDTOs.Add(
                    new CommentDTO(){ 
                        MainComment = comment, 
                        SubComments = subComments 
                        }
                );
            }   

            return commentDTOs;
        }

        // POST: api/Comments/5
        [HttpPost("{id}")]
        public async Task<IActionResult> ChangeCommentById(long id, string commentContent)
        {
            var original_comment = await _context.Comments.FindAsync(id);

            if (original_comment == null)
            {
                return NotFound();
            }

            if (commentContent != original_comment.CommentContent)
            {
                original_comment.CommentContent = commentContent;
                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw null;
                    }
                }
                return Ok();
            }
            return Ok();
        }

        // PUT: api/Comments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<IActionResult> PutComment(Comment comment)
        // {
        //     if (id != comment.Id)
        //     {
        //         return BadRequest();
        //     }

        //     _context.Entry(comment).State = EntityState.Modified;

        //     try
        //     {
        //         await _context.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!CommentExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }

        //     return NoContent();
        // }

        // POST: api/Comments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Comment>> PostComment(CommentPost commentPost)
        {
            var commentToPost = new Comment(){
                CommentContent = commentPost.CommentContent,
                ContentId = commentPost.ContentId,
                CommentedUserId = commentPost.CommentedUserId,
                CommentedUserName = commentPost.CommentedUserName,
                PostDate = DateTime.Now,
                Hidden = false,
                CommentLiked = 0,
                CommentDisliked = 0
            };
            if (commentPost.ParentId.HasValue)
            {
                commentToPost.ParentId = commentPost.ParentId;
            }

            _context.Comments.Add(commentToPost);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCommentsByContentId), commentToPost.ContentId);
        }

        // DELETE: api/Comments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(long id)
        {
            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }

            //_context.Comments.Remove(comment);
            comment.Hidden = true;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentExists(long id)
        {
            return _context.Comments.Any(e => e.Id == id);
        }
    }
}
