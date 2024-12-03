using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.Models
{
    public class massageReact:BaseEntity<string>
    {
        
        [ForeignKey("user")]
        public string? UserIdID { get; set; }
        public virtual User user { get; set; }
        [ForeignKey("massage")]
        public string? MassageId_fk { get; set; }
        public virtual Message massage { get; set; }
        [ForeignKey("react")]

        public string? Fk_ReactId { get; set; }
        public virtual React react { get; set; }
    }
}
