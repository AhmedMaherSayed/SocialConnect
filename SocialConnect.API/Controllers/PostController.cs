
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
    [Authorize]
    public class PostController : ControllerBase
    {
        UnitOfwork db;
        public PostController(UnitOfwork db)
        {
            this.db = db;
        }
        #region Get All
        [HttpGet()]
        // [Authorize(Roles = "User")]
        [SwaggerOperation(
            Summary = "Get all Post",
            Description = "Retrieve a list of Posts with optional filtering"
        )]
        [SwaggerResponse(200, "Successfully retrieved Posts", typeof(List<PostDTO>))]

        public IActionResult GetAll()
        {
            var posts = db.postrepository.Selectall();
            List<PostDTO> postsdto = new List<PostDTO>();
            foreach (var post in posts)
            {
                var po = new PostDTO()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Description = post.Description,
                    useId_fk = post.useId_fk,
                    countReact=post.Reacts.Count()
                    
                    

                };

                postsdto.Add(po);
            }
            if (postsdto.Count == 0)
                return NotFound();
            return Ok(postsdto);
        }
        [HttpGet("myPosts/")]
        [SwaggerOperation(
            Summary = "Get MY Post",
            Description = "Retrieve a list of Posts"
        )]
        [SwaggerResponse(200, "Successfully retrieved Posts", typeof(List<PostDTO>))]

        public IActionResult GetMyPpst()
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? HttpContext.Session.GetString("UserId");

            var posts = db.postRep.GetUserPost(userId);
            List<PostDTO> postsdto = new List<PostDTO>();
            foreach (var post in posts)
            {
                var po = new PostDTO()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Description = post.Description,
                    useId_fk = post.useId_fk,
                    countReact = post.Reacts.Count()


                };

                postsdto.Add(po);
            }
            if (postsdto.Count == 0)
                return NotFound();
            return Ok(postsdto);
        }
        [HttpGet("UserPosts/{userId}")]
        [SwaggerOperation(
            Summary = "Get User Post",
            Description = "Retrieve a list of Posts"
        )]
        [SwaggerResponse(200, "Successfully retrieved Posts", typeof(List<PostDTO>))]

        public IActionResult GetuserPost(string userId)
        {
           

            var posts = db.postRep.GetUserPost(userId);
            List<PostDTO> postsdto = new List<PostDTO>();
            foreach (var post in posts)
            {
                var po = new PostDTO()
                {
                    Id = post.Id,
                    Title = post.Title,
                    Description = post.Description,
                    useId_fk = post.useId_fk,
                    countReact = post.Reacts.Count()


                };

                postsdto.Add(po);
            }
            if (postsdto.Count == 0)
                return NotFound();
            return Ok(postsdto);
        }
        #endregion
        #region Get By ID
        [HttpGet("getPostById{id}")]
       
        [SwaggerOperation(
            Summary = "Get Post by Post ID",
            Description = "Retrieve a specific task using its unique identifier"
        )]
        [SwaggerResponse(200, "Task found", typeof(PostDTO))]
        [SwaggerResponse(404, "Task not found")]
        // [Authorize(Roles = "User")]
        public IActionResult Getbyid(string id)
        {
            var post = db.postrepository.GetById(id);
            if (post == null) return NotFound();
            var po = new PostDTO()
            {
                Id = post.Id,
                Title = post.Title,
                Description = post.Description,
                useId_fk = post.useId_fk,
                comments = post.comments,
                countReact = post.Reacts.Count()

            };
            return Ok(po);
        }
        #endregion
        #region Add Post
        [HttpPost]
       // [Authorize(Roles = "User")]
        [SwaggerResponse(201, "post created", typeof(Post))]
        [SwaggerResponse(400, "Post not found or not valid data")]
        [Consumes("application/json")]
        [SwaggerOperation(
    Summary = "Create post",
    Description = "Create post on PostTable",
    Tags = new[] { "User Operations" }
    )
    ]
        public IActionResult Add(AddPostDto po)
        {
            if (po == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                 string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)?? HttpContext.Session.GetString("UserId");
                
                var post = new Post()
                {
                    Id= $"{Guid.NewGuid():N}_{DateTime.UtcNow:yyyyMMddHHmmssfff}",
                    Title = po.Title,
                    Description = po.Description,
                    useId_fk = userId,
                    CreatedAt = DateTime.Now,


                };
                db.postrepository.Add(post);
                db.Save();
                return Created();
            }
            else
                return BadRequest(ModelState);
        }
        #endregion
        #region update Post
        [HttpPut("{id}")]
       // [Authorize(Roles = "User")]
        [SwaggerOperation(Summary = "Update post", Tags = new[] { "User Operations" })]
        public IActionResult Edit(string id, PostDTO po)
        {
            if (po == null)
                return BadRequest();
            if (po.Id != id)
                return BadRequest();

            var PostExists = db.postrepository.GetById(id);
            if (PostExists == null)
            {
                return BadRequest("post not Found.");
            }
             string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)?? HttpContext.Session.GetString("UserId");
            if (userId != PostExists.useId_fk)
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
        #endregion 
        #region Delete Post
        [HttpDelete("{id}")]
       // [Authorize(Roles = "User")]
        [SwaggerOperation(Summary = "Delete post", Tags = new[] { "User Operations" })]
        public IActionResult Delete(string id)
        {
            var post = db.postrepository.GetById(id);
            if (post == null) return NotFound();
            db.postrepository.Delete(post);
            db.Save();
            return Ok();
        }
        #endregion
        #region Add React to post
        [HttpPost(" React/{id}")]

       // [Authorize(Roles = "User")]
        [SwaggerResponse(201, "post created", typeof(Post))]
        [SwaggerResponse(400, "Post not found or not valid data")]
        [Consumes("application/json")]
        [SwaggerOperation(
    Summary = "Add React post",
    Description = "Create React on PostReact",
    Tags = new[] { "User Operations" }
    )
    ]
        public IActionResult AddPostReact(string id, ReactDTO com)
        {
            if (com == null)
                return BadRequest();

            if (ModelState.IsValid)
            {
                 string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)?? HttpContext.Session.GetString("UserId");
                var post = new postReacts()
                {
                    Id = $"{Guid.NewGuid():N}_{DateTime.UtcNow:yyyyMMddHHmmssfff}",

                    useId_fk = userId,
                    CreatedAt = DateTime.Now,
                    Fk_ReactId = com.Fk_ReactId,
                    Fk_postId = id



                };
                db.postReactsrepository.Add(post);
                db.Save();
                return Created();
            }
            else
                return BadRequest(ModelState);
        }
        #endregion
        #region Delete React Post
        [HttpDelete("React/{id}")]
        //[Authorize(Roles = "User")]
        [SwaggerOperation(Summary = "Delete Post React", Tags = new[] { "User Operations" })]
        public IActionResult DeleteReact(string id)
        {
            var com = db.postReactsrepository.GetById(id);
            if (com == null) return NotFound();
            db.postReactsrepository.Delete(com);
            db.Save();
            return Ok();
        }
        #endregion





    }
}
