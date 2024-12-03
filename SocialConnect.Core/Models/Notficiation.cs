
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.Models
{
    public class Notficiation
    {
        public int Id { get; set; }
        public string description { get; set; }
        public string? UserId { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.Now;
        public string? URL {  get; set; }
        public bool ? Seen { get; set; }


    }
}
