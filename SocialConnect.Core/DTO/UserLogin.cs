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
        [RegularExpression("[A-Za-z]+", ErrorMessage = "Username does not cantain any number")]
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
    }
}
