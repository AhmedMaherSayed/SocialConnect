using SocialConnect.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.DTO
{
    public class ReactDTO
    {
        public string? Id { get; set; }
        public string? Fk_postId { get; set; }
       

        public string? Fk_ReactId { get; set; }
       
        public string? useId_fk { get; set; }

    }
}
