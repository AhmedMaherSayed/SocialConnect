using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.Models
{
    public class Comment : BaseEntity<string>
    {
        public string Title { get; set; }
        [ForeignKey("post")]

        public string? Fk_postId { get; set; }
        [ForeignKey("comment")]

        public string? Fk_CommentId { get; set; }
        [ForeignKey("user")]
        public string? useId_fk { get; set; }
        public virtual User user { get; set; }
        public virtual Post post { get; set; }
        public virtual Comment comment { get; set; }
        public virtual List<Comment> comments { get; set; }= new List<Comment>();
       


    }
}
