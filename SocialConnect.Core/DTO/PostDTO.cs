using SocialConnect.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.DTO
{
    public class PostDTO
    {
        public string Id {  get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        
        public string? useId_fk { get; set; }
        public int countReact {  get; set; }
      
        public virtual List<Comment> comments { get; set; }= new List<Comment>();
        public virtual List<React> Reacts { get; set; }= new List<React>();
    }
}
