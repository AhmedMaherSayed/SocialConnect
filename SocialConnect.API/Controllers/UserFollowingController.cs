using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;


using SocialConnect.Core.DTO;
using SocialConnect.Core.Models;
using SocialConnect.Service;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using SocialConnect.API.Helpers;
using Microsoft.AspNetCore.Authorization;

namespace SocialConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ Authorize]
    public class UserFollowingController : ControllerBase
    {
        private readonly UnitOfwork _unitOfWork;
        private readonly IHubContext<MyHub> massageHub;

        public UserFollowingController(UnitOfwork unitOfWork,IHubContext<MyHub> MassageHub)
        {
            _unitOfWork = unitOfWork;
            massageHub = MassageHub;
        }

        [HttpGet("{userId}")]
        [SwaggerOperation(
            Summary = "Get My Following User"
        )]
        [SwaggerResponse(200, "Successfully retrieved User", typeof(List<UserFrindDTo>))]

        public IActionResult GetAllFollwingUser()
        {
            string MyId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? HttpContext.Session.GetString("UserId");
            var conversations = _unitOfWork.frindAndFolloingAndNotficationUserRep.UserFollowing(MyId);
            return Ok(conversations);
        }
       
       
        #region Delete Following
        [HttpDelete("{id}")]
        // [Authorize(Roles = "User")]
        [SwaggerOperation(Summary = "Delete Follwing User", Tags = new[] { "User Operations" })]
        public IActionResult Delete(string id)
        {
            string MyId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? HttpContext.Session.GetString("UserId");

            
            _unitOfWork.frindAndFolloingAndNotficationUserRep.Deletefollwing(id,MyId);
           
            return Ok();
        }
        #endregion

        //[HttpGet("messages/{conversationId}")]
        //public IActionResult GetMessages(string conversationId)
        //{
        //    var messages = _unitOfWork.Conversations;
        //    return Ok(messages);
        //}

        [HttpPost("send{userId}")]
        [SwaggerOperation(
            Summary = "Following User User"
        )]
        [SwaggerResponse(201, "Following User successfully", typeof(UserFrindDTo))]
        [SwaggerResponse(400, "Invalid task data")]
        public async Task <IActionResult> AddFollwingUser(string userId,[FromBody] string massage)
        {
            string MyId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? HttpContext.Session.GetString("UserId");

            var Following = new FollowingUser
            {
                Id = $"{Guid.NewGuid():N}_{DateTime.UtcNow:yyyyMMddHHmmssfff}",
                FollowinguseId_fk = userId,
                user_Id = MyId,
                CreatedAt= DateTime.Now,


            };

            _unitOfWork.followingUserReactsrepository.Add(Following);
            //signalR
           await massageHub.Clients.User(userId).SendAsync($"massage From{MyId}", Following.Id);
            _unitOfWork.Save();
            return Ok(Following);
        }
    }

}
