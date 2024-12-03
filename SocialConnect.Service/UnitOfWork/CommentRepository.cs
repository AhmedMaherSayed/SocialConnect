using SocialConnect.Core.DTO;
using SocialConnect.Core.Models;
using SocialConnect.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Service.UnitOfWork
{
    public class CommentRepository
    {
        protected ApplicationDbContext db;
        public CommentRepository(ApplicationDbContext db)
        {
            this.db = db;

        }
        public List<Comment> GetCommentByPostId(string id)
        {
           
            var x = db.Comments.Where(x=>x.Fk_postId==id).ToList();
            if (x == null)
            {
                return null;
            }
           
            return x;
        }
    }
}
