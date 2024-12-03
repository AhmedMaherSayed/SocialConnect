using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.Models
{
    public class SavedPost :BaseEntity<string>
    {
        [ForeignKey("post")]

        public string? Fk_postId { get; set; }
        public virtual Post post { get; set; }
     
        [ForeignKey("user")]
        public string? useId_fk { get; set; }
        public virtual User user { get; set; }
    }
}
