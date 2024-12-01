
using Bookstore.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using SocialConnect.Core.DTO;
using SocialConnect.Core.Models;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
namespace SocialConnect.API.Controllers

{
    [Route("[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "posts")]
    public class PostController : ControllerBase
    {
        UnitOfwork db;
        public PostController(UnitOfwork db)
        {
            this.db = db;
        }
        [HttpGet]
        [Authorize(Roles = "User")]
        public IActionResult GetAll()
        {
            var posts = db.postrepository.Selectall();
            List<PostDTO> postsdto = new List<PostDTO>();
            foreach (var post in posts)
            {
                var po = new PostDTO()
                {
                    Id=post.Id,
                    Title= post.Title,
                    Description= post.Description,
                    useId_fk=post.useId_fk,
                    
                };
               
                postsdto.Add(po);
            }
            if (postsdto.Count == 0)
                return NotFound();
            return Ok(postsdto);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "User")]
        public IActionResult Getbyid(int id) {
        var post = db.postrepository.GetById(id);
        if(post == null) return NotFound();
            var po = new PostDTO()
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                useId_fk = post.useId_fk,

            };
            return Ok(po);
        }
        [HttpPost]
        [Authorize(Roles = "User")]
        [SwaggerResponse(201, "post created",typeof(Post))]
        [SwaggerResponse(400, "Post not found or not valid data")]
        [Consumes("application/json")]
        [SwaggerOperation(
            Summary = "Create post",
            Description = "Create post on PostTable",
            Tags = new[] {"User Operations"}
            )
            ]
        public IActionResult Add(PostDTO po)
        {
            if (po == null)
                return BadRequest();
           
            if (ModelState.IsValid)
            {
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
                var post = new Post()
                {
                    Title = po.Title,
                    Description = po.Description,
                    useId_fk = userId,
                    CreatedAt=DateTime.Now,
                    

                };
                db.postrepository.Add(post);
                db.Save();
                return Created();
            }
            else
                return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        [Authorize(Roles = "User")]
        [SwaggerOperation(Summary = "Update post", Tags = new[] { "User Operations" })]
        public IActionResult Edit(string id, PostDTO po)
        {
            if (po == null)
                return BadRequest();
            if(po.Id != id)
                return BadRequest();
           
            var PostExists = db.postrepository.GetById(id);
            if (PostExists ==null)
            {
                return BadRequest("post not Found.");
            }
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId!=PostExists.useId_fk)
            {
                return BadRequest("Post not Access.");
            }
            if (ModelState.IsValid)
            {
                var post = new Post()
                {
                    Title = po.Title,
                    Description = po.Description,
                    

                };
                db.postrepository.Edit(post);
                db.Save();
                return Ok();
            }
            else return BadRequest(ModelState);
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = "User")]
        [SwaggerOperation(Summary = "Delete post", Tags = new[] { "User Operations" })]
        public IActionResult Delete(string id)
        {
            var post = db.postrepository.GetById(id);
            if (post == null) return NotFound();
            db.postrepository.Delete(post);
            db.Save();
            return Ok();
        }
    }
}
