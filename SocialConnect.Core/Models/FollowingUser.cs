using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.Models
{
    public class FollowingUser : BaseEntity<Guid>
    {
        [ForeignKey("user")]
        public Guid MyID { get; set; }
        public virtual User user { get; set; }
        [ForeignKey("users")]
        public Guid FollowinguseId_fk { get; set; }
        public virtual User users { get; set; }
    }
}
