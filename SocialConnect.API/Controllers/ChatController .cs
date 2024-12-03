using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;


using SocialConnect.Core.DTO;
using SocialConnect.Core.Models;
using SocialConnect.Service;
using Swashbuckle.AspNetCore.Annotations;
using System.Security.Claims;
using SocialConnect.API.Helpers;

namespace SocialConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly UnitOfwork _unitOfWork;
        private readonly IHubContext<MyHub> massageHub;

        public ChatController(UnitOfwork unitOfWork,IHubContext<MyHub> MassageHub)
        {
            _unitOfWork = unitOfWork;
            massageHub = MassageHub;
        }

        [HttpGet("conversations/{userId}")]
        [SwaggerOperation(
            Summary = "Get Chat betwen me And User",
            Description = "Retrieve a list of Massage with optional filtering"
        )]
        [SwaggerResponse(200, "Successfully retrieved Massage", typeof(List<Message>))]

        public IActionResult GetConversations(string userId)
        {
            string MyId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? HttpContext.Session.GetString("UserId");
            var conversations = _unitOfWork.Conversations.GetUserConversations(MyId,userId);
            return Ok(conversations);
        }

        //[HttpGet("messages/{conversationId}")]
        //public IActionResult GetMessages(string conversationId)
        //{
        //    var messages = _unitOfWork.Conversations;
        //    return Ok(messages);
        //}

        [HttpPost("send{userId}")]
        [SwaggerOperation(
            Summary = "Send Massage",
            Description = "massage"
        )]
        [SwaggerResponse(201, "Massage Send successfully", typeof(Message))]
        [SwaggerResponse(400, "Invalid task data")]
        public async Task <IActionResult> SendMessage(string userId,[FromBody] string massage)
        {
            string MyId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? HttpContext.Session.GetString("UserId");

            var message = new Message
            {
                Id = $"{Guid.NewGuid():N}_{DateTime.UtcNow:yyyyMMddHHmmssfff}",

                Content = massage,
                SenderId = MyId,
                ReceiverId = userId,
                SentAt = DateTime.UtcNow
            };

            _unitOfWork.Conversations.AddMessage(message);
            //signalR
           await massageHub.Clients.User(userId).SendAsync($"massage From{MyId}", message);
            _unitOfWork.Save();
            return Ok(message);
        }
    }

}
