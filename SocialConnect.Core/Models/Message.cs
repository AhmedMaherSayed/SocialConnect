using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.Models
{
    public class Message : BaseEntity<string>
    {


       
        public string Content { get; set; }
        public DateTime SentAt { get; set; }
        [ForeignKey("Sender")]
        public string SenderId { get; set; }
       
        public string ReceiverId { get; set; }

       


    }
}
