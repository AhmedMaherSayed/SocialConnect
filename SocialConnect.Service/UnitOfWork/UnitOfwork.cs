
using SocialConnect.Core.Models;
using SocialConnect.Repository.Data;
using SocialConnect.Service;

namespace SocialConnect.Service
{
    public class UnitOfwork
    {
        ApplicationDbContext db;
        GenericRepository<Post> Postrepository;
        
        public UnitOfwork(ApplicationDbContext db )
        {
            this.db = db;
        }
        public GenericRepository<Post> postrepository
        {
            get
            {
                if (Postrepository == null)
                {
                    Postrepository = new GenericRepository<Post>(db);
                }
                return Postrepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

    }
}
