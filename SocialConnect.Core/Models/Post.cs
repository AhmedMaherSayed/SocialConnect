using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.Models
{
    public class Post:BaseEntity<string>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        [ForeignKey("user")]
        public string? useId_fk { get; set; }
        public virtual User user { get; set; }
        public virtual List<Comment> comments { get; set; } = new List<Comment>();



    }
}
