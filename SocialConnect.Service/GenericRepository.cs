using SocialConnect.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Service
{
    public class GenericRepository<T> where T : class
    {
        protected ApplicationDbContext db;
        public GenericRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<T> Selectall()
        {
            return db.Set<T>().ToList();
        }
        public T GetById(int id)
        {
            var x = db.Set<T>().Find(id);
            if (x == null)
            {
                return null;
            }
            return x;
        }
        public T GetById(string id)
        {
            var x = db.Set<T>().Find(id);
            if (x == null)
            {
                return null;
            }
            return x;
        }
        public void Add(T Entity)
        {
            
            db.Set<T>().Add(Entity);
        }
        public void Delete(T Entity)
        {
            db.Set<T>().Remove(Entity);
        }
        public void Edit(T Entity)
        {
            db.Update(Entity);
        }
    }
    
}
