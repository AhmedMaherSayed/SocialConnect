using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.Models
{
    public class massageReact:BaseEntity<Guid>
    {
        public virtual User user { get; set; }
        [ForeignKey("users")]
        public Guid UserIdID { get; set; }
        public virtual User users { get; set; }

        [ForeignKey("massage")]
        public Guid? MassageId_fk { get; set; }
        public virtual Massage massage { get; set; }
        [ForeignKey("react")]

        public Guid Fk_ReactId { get; set; }
        public virtual React react { get; set; }
    }
}
