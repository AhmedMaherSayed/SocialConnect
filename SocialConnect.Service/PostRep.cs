using SocialConnect.Core.Models;
using SocialConnect.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Service
{
    public class PostRep
    {

        protected ApplicationDbContext db;
        public PostRep(ApplicationDbContext db)
        {
            this.db = db;

        }
        public List<Post> GetUserPost(string id)
        {

            var x = db.Posts.Where(x => x.useId_fk == id).ToList();
            if (x == null)
            {
                return null;
            }

            return x;
        }
    }
}
