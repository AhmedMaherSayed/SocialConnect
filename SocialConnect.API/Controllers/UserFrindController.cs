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
    public class UserFrindController : ControllerBase
    {
        private readonly UnitOfwork _unitOfWork;
        private readonly IHubContext<MyHub> massageHub;

        public UserFrindController(UnitOfwork unitOfWork,IHubContext<MyHub> MassageHub)
        {
            _unitOfWork = unitOfWork;
            massageHub = MassageHub;
        }

        [HttpGet("{userId}")]
        [SwaggerOperation(
            Summary = "Get My Frinds User"
        )]
        [SwaggerResponse(200, "Successfully retrieved User", typeof(List<UserFrindDTo>))]

        public IActionResult GetAllFrindUser()
        {
            string MyId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? HttpContext.Session.GetString("UserId");
            var conversations = _unitOfWork.frindAndFolloingAndNotficationUserRep.GetUserFrinds(MyId);
            return Ok(conversations);
        }
        [HttpGet("Approd Connection")]
        [SwaggerOperation(
            Summary = "Approd Connection"
        )]
        [SwaggerResponse(200, "Successfully retrieved User", typeof(List<UserFrindDTo>))]

        public IActionResult GetUserAproveFrinds()
        {
            string MyId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? HttpContext.Session.GetString("UserId");
            var conversations = _unitOfWork.frindAndFolloingAndNotficationUserRep.GetUserAproveFrinds(MyId);
            return Ok(conversations);
        }
        #region Delete Frinds
        [HttpDelete("{id}")]
        // [Authorize(Roles = "User")]
        [SwaggerOperation(Summary = "Delete frind", Tags = new[] { "User Operations" })]
        public IActionResult Delete(string id)
        {
            string MyId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? HttpContext.Session.GetString("UserId");

            
            _unitOfWork.frindAndFolloingAndNotficationUserRep.DeleteFrinds(id,MyId);
           
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
            Summary = "Send Connection To User"
        )]
        [SwaggerResponse(201, "Connection Send successfully", typeof(UserFrindDTo))]
        [SwaggerResponse(400, "Invalid task data")]
        public async Task <IActionResult> SendMessage(string userId,[FromBody] string massage)
        {
            string MyId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? HttpContext.Session.GetString("UserId");

            var frindUser = new FrindsUser
            {
                Id = $"{Guid.NewGuid():N}_{DateTime.UtcNow:yyyyMMddHHmmssfff}",
                FrindsId_fk = userId,
                user_Id = MyId,
                CreatedAt= DateTime.Now,


            };

            _unitOfWork.frindsUserrepository.Add(frindUser);
            //signalR
           await massageHub.Clients.User(userId).SendAsync($"massage From{MyId}", frindUser.Id);
            _unitOfWork.Save();
            return Ok(frindUser);
        }
    }

}
