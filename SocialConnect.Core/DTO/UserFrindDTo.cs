using SocialConnect.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.DTO
{
    public class UserFrindDTo
    {
        public string Id {  get; set; }
        public string? user_Id { get; set; }
      
        public string? FrindsId_fk { get; set; }
        public User User { get; set; }
        public bool Aprove { get; set; }
    }
    public class FollowingUserDTo
    {
        public string Id { get; set; }
        public string? user_Id { get; set; }

        public string? FrindsId_fk { get; set; }
        public User User { get; set; }



    }
}
