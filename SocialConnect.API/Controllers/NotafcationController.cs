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
    public class NotafcationController : ControllerBase
    {
        private readonly UnitOfwork _unitOfWork;
        private readonly IHubContext<MyHub> massageHub;

        public NotafcationController(UnitOfwork unitOfWork,IHubContext<MyHub> MassageHub)
        {
            _unitOfWork = unitOfWork;
            massageHub = MassageHub;
        }

        [HttpGet("{userId}")]
        [SwaggerOperation(
            Summary = "Get My Notofacation"
        )]
        [SwaggerResponse(200, "Successfully retrieved User", typeof(List<UserFrindDTo>))]

        public IActionResult GetUserNetfcation()
        {
            string MyId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? HttpContext.Session.GetString("UserId");
            var conversations = _unitOfWork.frindAndFolloingAndNotficationUserRep.GetUserFrinds(MyId);
            return Ok(conversations);
        }
        [HttpPut("{NoficationId}")]
        [SwaggerOperation(
           Summary = "Update  Notofacation To B Seen"
       )]
        [SwaggerResponse(200, "Successfully retrieved User", typeof(List<UserFrindDTo>))]

        public IActionResult GetUserNetfcation(string NoficationId)
        {
           // string MyId = User.FindFirstValue(ClaimTypes.NameIdentifier) ?? HttpContext.Session.GetString("UserId");
             _unitOfWork.frindAndFolloingAndNotficationUserRep.UpdateNetfcation(NoficationId);
            return Ok();
        }



    }

}
