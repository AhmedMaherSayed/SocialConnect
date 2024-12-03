using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.DTO
{
    public class UserLogin
    {
        
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
