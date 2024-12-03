using SocialConnect.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.DTO
{
    public class CommentDTO
    {
       
        public string Title { get; set; }

        [Required]
        public string? Fk_postId { get; set; }
       

        public string? Fk_CommentId { get; set; }
       
        public string? useId_fk { get; set; }
     
       

        public virtual List<Comment> comments { get; set; } = new List<Comment>();
        public virtual List<React> Reacts { get; set; } = new List<React>();
    }
}
