using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.Models
{
    public class FrindsUser : BaseEntity<string>
    {
        [ForeignKey("My")]
        public string? user_Id { get; set; }
        public virtual User My { get; set; }
        [ForeignKey("Frind")]
        public string? FrindsId_fk { get; set; }
        public virtual User Frind { get; set; }
        public bool Aprove { get; set; }
    }
}
