using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SocialConnect.Core.DTO;
using SocialConnect.Core.Models;
using System.Net;

namespace SocialConnect.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> role;

        public UserController(UserManager<IdentityUser> userManager,RoleManager<IdentityRole>role)
        {
            this.userManager = userManager;
            this.role = role;
        }
        [HttpPost]
        public IActionResult AddUser(UserDto model)
        {
            if (ModelState.IsValid)
            {
                User user = new User()
                {
                    Email = model.Email,
                    UserName = model.username,
                    PhoneNumber = model.PhoneNumber,
                    address = model.Address,


                };
                IdentityResult r= userManager.CreateAsync(user,model.password).Result;
                if (r.Succeeded)
                {
                 IdentityRole ro=  role.FindByNameAsync("User").Result;
                    if (ro != null)
                    {
                        IdentityResult rr = userManager.AddToRoleAsync(user, ro.Name).Result;
                        if (rr.Succeeded)
                        {
                            return Created();
                        }
                        else return BadRequest(rr.Errors);
                    }
                    else return BadRequest("Role Not Found");
                }
                else return BadRequest(r.Errors);
            }

            return BadRequest(ModelState.ErrorCount);
        }
        [HttpGet]
        public IActionResult Get()
        {
            // var Users = db.Userrepository.Selectall();
            var Users = userManager.GetUsersInRoleAsync("User").Result.OfType<User>().ToList();
            List<UserDto> Usersdto = new List<UserDto>();
            foreach (var User in Users)
            {
                var cs = new UserDto(){ 
                Id = User.Id,
                username = User.UserName,
                Email = User.Email,
                Address = User.address,
                PhoneNumber = User.PhoneNumber};

                Usersdto.Add(cs);
            }
            if (Usersdto.Count == 0)
                return NotFound();
            return Ok(Usersdto);
        }
        [HttpGet("{id}")]
        public IActionResult GetbyId(string id)
        {
            var cs = (User)userManager.GetUsersInRoleAsync("User").Result.Where(c => c.Id == id).SingleOrDefault();
            if (cs == null) return NotFound();
            var CS = new UserDto()
            {
                Id=id,
                username = cs.UserName,
              
                Email = cs.Email,
                Address = cs.address,
                PhoneNumber = cs.PhoneNumber
            };
            return Ok(CS);
        }
        [HttpPut]
        public IActionResult Edit(UserDto UserEditDTO)
        {
            if (ModelState.IsValid)
            {
                var cs = (User)userManager.FindByIdAsync(UserEditDTO.Id).Result;
                if (cs == null) return NotFound();
                cs.Id = UserEditDTO.Id;
                cs.PhoneNumber = UserEditDTO.PhoneNumber;
                cs.address = UserEditDTO.Address??cs.PhoneNumber;
                cs.Email = UserEditDTO.Email??cs.Email;
                cs.UserName = UserEditDTO.username??cs.UserName;
               
                var res = userManager.UpdateAsync(cs).Result;
                if (res.Succeeded)
                    return Ok();
                else
                    return BadRequest();
                //db.Userrepository.Edit(cs);
                //db.Save();
                //return Ok();
            }
            else
                return BadRequest(ModelState);
        }
    }
}
