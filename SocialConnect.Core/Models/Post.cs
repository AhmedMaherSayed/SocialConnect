using System.ComponentModel.DataAnnotations.Schema;

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
        public virtual List<React> Reacts { get; set; } = new List<React>();



    }
}
