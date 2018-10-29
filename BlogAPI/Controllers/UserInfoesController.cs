using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogAPI.Models;

namespace BlogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfoesController : ControllerBase
    {
        private readonly BlogAPIContext _context;

        public UserInfoesController(BlogAPIContext context)
        {
            _context = context;
        }

        // GET: api/UserInfoes
        [HttpGet]
        public IEnumerable<UserInfo> GetUserInfos()
        {
            return from Userinfo in _context.UserInfos
                   join comments in _context.Comments on Userinfo equals comments.CommentingUser into userComments
                   join post in _context.Posts on Userinfo equals post.PostingUser into userPosts
                   select new UserInfo()
                   {
                       Comments = new List<Comment>(userComments),
                       Name = Userinfo.Name,
                       NumberOfComments = Userinfo.NumberOfComments,
                       NumberOfPosts = Userinfo.NumberOfPosts,
                       Posts = (ICollection<Post>)userPosts,
                       ProfilPictureUrl = Userinfo.ProfilPictureUrl,
                       RegisterDate = Userinfo.RegisterDate,
                       UserInfoID = Userinfo.UserInfoID,
                       Username = Userinfo.Username
                   };
        }

        // GET: api/UserInfoes/5
        [HttpGet("{id}")]
        public IActionResult GetUserInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var comment = from Userinfo in _context.UserInfos
                          join comments in _context.Comments on Userinfo equals comments.CommentingUser into userComments
                          join post in _context.Posts on Userinfo equals post.PostingUser into userPosts
                          select new UserInfo()
                          {
                              Comments = new List<Comment>(userComments),
                              Name = Userinfo.Name,
                              NumberOfComments = Userinfo.NumberOfComments,
                              NumberOfPosts = Userinfo.NumberOfPosts,
                              Posts = (ICollection<Post>)userPosts,
                              ProfilPictureUrl = Userinfo.ProfilPictureUrl,
                              RegisterDate = Userinfo.RegisterDate,
                              UserInfoID = Userinfo.UserInfoID,
                              Username = Userinfo.Username

                          };

            if (comment.FirstOrDefault(c => c.UserInfoID == id) == null)
            {
                return NotFound();
            }

            return Ok(comment.FirstOrDefault(c => c.UserInfoID == id));
        }

        // PUT: api/UserInfoes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUserInfo([FromRoute] int id, [FromBody] UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != userInfo.UserInfoID)
            {
                return BadRequest();
            }

            _context.Entry(userInfo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserInfoExists(id))
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

        // POST: api/UserInfoes
        [HttpPost]
        public async Task<IActionResult> PostUserInfo([FromBody] UserInfo userInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.UserInfos.Add(userInfo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUserInfo", new { id = userInfo.UserInfoID }, userInfo);
        }

        // DELETE: api/UserInfoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUserInfo([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userInfo = await _context.UserInfos.FindAsync(id);
            if (userInfo == null)
            {
                return NotFound();
            }

            _context.UserInfos.Remove(userInfo);
            await _context.SaveChangesAsync();

            return Ok(userInfo);
        }

        private bool UserInfoExists(int id)
        {
            return _context.UserInfos.Any(e => e.UserInfoID == id);
        }
    }
}
