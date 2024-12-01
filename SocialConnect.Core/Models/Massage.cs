using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.Models
{
    public class Massage:BaseEntity<string>
    {

       
        public string MyID { get; set; }
        

        public string UserIdID { get; set; }

        //public virtual User user { get; set; }
       




        [ForeignKey("massage")]
        public string? MassageId_fk { get; set; }
        public virtual Massage massage { get; set; }
        public virtual List<Massage> Massages { get; set; } = new List<Massage>();



    }
}
