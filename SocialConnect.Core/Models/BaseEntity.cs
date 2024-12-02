using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.Models
{
    public class BaseEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
        public bool IsDeleted { get; set; }
        //public int CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        //public int? ModefiedBy { get; set; }
        public DateTime? ModefiedAt { get; set; }
    }
}
