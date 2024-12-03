using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.DTO
{
    public class UserDto
    {
        public string Id { get; set; }
        public string username { get; set; }
        [Required]
    
        public string password { get; set; }
       
        [Compare("password", ErrorMessage = "The password and confirmation password do not match.")]
        public string Confirmpassword { get; set; }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        [Required]
       // [RegularExpression("[a-zA-Z0-9-_]+@gmail.com", ErrorMessage = "Please enter a valid Gmail address.")]
        public string Email { get; set; }

    }
}
