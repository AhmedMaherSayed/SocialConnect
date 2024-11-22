using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.Models
{
    public class CommentReact : BaseEntity<string>
    {
        [ForeignKey("comment")]

        public string? Fk_postId { get; set; }
        public virtual Comment comment { get; set; }
        [ForeignKey("react")]

        public string?Fk_ReactId { get; set; }
        public virtual React react { get; set; }
        [ForeignKey("user")]
        public string? useId_fk { get; set; }
        public virtual User user { get; set; }
    }
}
