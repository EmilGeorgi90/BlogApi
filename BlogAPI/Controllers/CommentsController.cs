using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Models;
using Blog.Web.Models;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly BlogAPIContext _context;

        public CommentsController(BlogAPIContext context)
        {
            _context = context;
        }

        // GET: api/BlogAPI
        [HttpGet]
        public IEnumerable<CommentDTO> GetComments()
        {
            var comment = from Userinfo in _context.UserInfos
                   join comments in _context.Comments on Userinfo equals comments.CommentingUser into comments
                   from p in comments.DefaultIfEmpty()
                   join post in _context.Posts on Userinfo equals post.PostingUser
                   select new Comment()
                   {
                       CommentId = p == null ? 0 : p.CommentId,
                       CommentingUser = Userinfo,
                       Content = p.Content,
                       DateOfComment = p == null ? DateTime.Now : p.DateOfComment,
                       Post = new Post()
                       {
                           Content = post.Content,
                           DateOfPost = post.DateOfPost,
                           PostId = post.PostId,
                           PostingUser = post.PostingUser,
                           Title = post.Title
                       }
                   };
            foreach (Comment item in comment)
            {
                yield return AutoMapper.Mapper.Map<Comment, CommentDTO>(item);
            }
        }

        // GET: api/BlogAPI/5
        [HttpGet("{id}")]
        public IActionResult GetComments([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = from Userinfo in _context.UserInfos
                           join comments in _context.Comments on Userinfo equals comments.CommentingUser
                           join post in _context.Posts on Userinfo equals post.PostingUser
                           select new Comment()
                           {
                               CommentId = comments.CommentId,
                               CommentingUser = Userinfo,
                               Content = comments.Content,
                               DateOfComment = comments.DateOfComment,
                               Post = new Post()
                               {
                                   Content = post.Content,
                                   DateOfPost = post.DateOfPost,
                                   PostId = post.PostId,
                                   PostingUser = post.PostingUser,
                                   Title = post.Title
                               }
                           };
            CommentDTO dto = AutoMapper.Mapper.Map<Comment, CommentDTO>(comment.FirstOrDefault());
            if (comment.FirstOrDefault(c => c.CommentId == id) == null)
            {
                return NotFound();
            }

            return Ok(dto);
        }

        // PUT: api/BlogAPI/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutComments([FromRoute] int id, [FromBody] Comment comments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != comments.CommentId)
            {
                return BadRequest();
            }

            _context.Entry(comments).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/BlogAPI
        [HttpPost]
        public async Task<IActionResult> PostComments([FromBody] Comment comments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Comments.Add(comments);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetComments", new { id = comments.CommentId }, comments);
        }

        // DELETE: api/BlogAPI/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComments([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comments = await _context.Comments.FindAsync(id);
            if (comments == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comments);
            await _context.SaveChangesAsync();

            return Ok(comments);
        }

        private bool CommentsExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }
    }
}
