using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.Models
{
    public class Massage:BaseEntity<Guid>
    {

        [ForeignKey("user")]
        public Guid MyID { get; set; }
        public virtual User user { get; set; }
        [ForeignKey("users")]
        public Guid UserIdID { get; set; }
        public virtual User users { get; set; }

        [ForeignKey("massage")]
        public Guid? MassageId_fk { get; set; }
        public virtual Massage massage { get; set; }
        public virtual List<Massage> Massages { get; set; } = new List<Massage>();



    }
}
