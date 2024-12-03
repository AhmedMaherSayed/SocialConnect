
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SocialConnect.Core.DTO;
using SocialConnect.Core.Models;
using SocialConnect.Service;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
namespace SocialConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
   
    public class CommentController : ControllerBase
    {
        UnitOfwork db;
        public CommentController(UnitOfwork db)
        {
            this.db = db;
        }
       
        #region Add Comment to post
        [HttpPost("{id}")]
       
        [Authorize(Roles = "User")]
        [SwaggerResponse(201, "Comment created", typeof(AddCommentDto))]
        [SwaggerResponse(400, "Post not found or not valid data")]
        [Consumes("application/json")]
        [SwaggerOperation(
    Summary = "Add Comment to Post",
    Tags = new[] { "User Operations" }
    )
    ]
        public IActionResult Add(string id, AddCommentDto com)
        {
            if (com == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                 string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)?? HttpContext.Session.GetString("UserId");
                var post = new Comment()
                {
                    Id= $"{Guid.NewGuid():N}_{DateTime.UtcNow:yyyyMMddHHmmssfff}",
                    Title = com.Title,
                    useId_fk = userId,
                    CreatedAt = DateTime.Now,
                    Fk_CommentId=com.Fk_CommentId,
                    Fk_postId=id



                };
                db.commentrepository.Add(post);
                db.Save();
                return Created();
            }
            else
                return BadRequest(ModelState);
        }
        #endregion
        #region Add React to post
        [HttpPost(" React/{id}")]

        [Authorize(Roles = "User")]
        [SwaggerResponse(201, "React created", typeof(Post))]
        [SwaggerResponse(400, "Post not found or not valid data")]
        [Consumes("application/json")]
        [SwaggerOperation(
    Summary = "Add React to comment",
   
    Tags = new[] { "User Operations" }
    )
    ]
        public IActionResult AddCommentReact(string id, ReactDTO com)
        {
            if (com == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                 string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)?? HttpContext.Session.GetString("UserId");
                var post = new CommentReact()
                {
                    Id = $"{Guid.NewGuid():N}_{DateTime.UtcNow:yyyyMMddHHmmssfff}",
                   
                    useId_fk = userId,
                    CreatedAt = DateTime.Now,
                   Fk_ReactId=com.Fk_ReactId,
                    Fk_postId = id



                };
                db.commentReactsrepository.Add(post);
                db.Save();
                return Created();
            }
            else
                return BadRequest(ModelState);
        }
        #endregion
        #region update Post
        [HttpPut("{id}")]
        [Authorize(Roles = "User")]
        [SwaggerOperation(Summary = "Update Post ", Tags = new[] { "User Operations" })]
        public IActionResult Edit(string id, AddCommentDto po)
        {
            if (po == null)
                return BadRequest();
           

            var CommentExists = db.commentrepository.GetById(id);
            if (CommentExists == null)
            {
                return BadRequest("post not Found.");
            }
             string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)?? HttpContext.Session.GetString("UserId");
            if (userId != CommentExists.useId_fk)
            {
                return BadRequest("Post not Access.");
            }
            if (ModelState.IsValid)
            {
                var post = new Comment()
                {
                    Title = po.Title,
                    ModefiedAt=DateTime.Now,
                   


                };
                db.commentrepository.Edit(post);
                db.Save();
                return Ok();
            }
            else return BadRequest(ModelState);
        }
        #endregion 
        #region Delete Comment
        [HttpDelete("{id}")]
        [Authorize(Roles = "User")]
        [SwaggerOperation(Summary = "Delete Comment", Tags = new[] { "User Operations" })]
        public IActionResult Delete(string id)
        {
            var com = db.commentrepository.GetById(id);
            if (com == null) return NotFound();
            db.commentrepository.Delete(com);
            db.Save();
            return Ok();
        }
        #endregion
        #region Delete React Comment
        [HttpDelete("React/{id}")]
        [Authorize(Roles = "User")]
        [SwaggerOperation(Summary = "Comment React", Tags = new[] { "User Operations" })]
        public IActionResult DeleteReact(string id)
        {
            var com = db.commentReactsrepository.GetById(id);
            if (com == null) return NotFound();
            db.commentReactsrepository.Delete(com);
            db.Save();
            return Ok();
        }
        #endregion
        #region Get By ID
        [HttpGet("{id}")]
        [SwaggerOperation(
            Summary = "Get Post Comment",
            Description = "Retrieve Comment using its unique identifier Post Id"
        )]
        [SwaggerResponse(200, "Task found", typeof(Comment))]
        [SwaggerResponse(404, "Task not found")]
        [Authorize(Roles = "User")]
        public IActionResult Getbyid(string id)
        {
            var post = db.comment.GetCommentByPostId(id);
            if (post == null) return NotFound();
          
            return Ok(post);
        }
        #endregion





    }
}
