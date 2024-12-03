using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.DTO
{
    public class AddCommentDto
    {
        public string Title { get; set; }

       
        public string? Fk_postId { get; set; }


        public string? Fk_CommentId { get; set; }

       

    }
}
