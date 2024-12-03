
using SocialConnect.Core.DTO;
using SocialConnect.Core.Models;
using SocialConnect.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SocialConnect.Service
{
    public class FrindAndFolloingAndNotficationUserRep
    {
        protected ApplicationDbContext db;
        public FrindAndFolloingAndNotficationUserRep(ApplicationDbContext db)
        {
            this.db = db;

        }
        #region Frind
        public List<UserFrindDTo> GetUserFrinds(string id)
        {
            List<UserFrindDTo>list= new List<UserFrindDTo>();
            var x = db.FrindsUsers.Where(x => x.user_Id == id&&x.Aprove==true).ToList();
            if (x == null)
            {
                return null;
            }
            foreach (var item in x)
            {
                UserFrindDTo f
                    = new UserFrindDTo();
                f.FrindsId_fk = item.FrindsId_fk;
                f.User = db.User.Find(item.FrindsId_fk);
                list.Add(f);
            }
            return list ;
        }
        public List<UserFrindDTo> GetUserAproveFrinds(string id)
        {
            List<UserFrindDTo> list = new List<UserFrindDTo>();
            var x = db.FrindsUsers.Where(x => x.user_Id == id && x.Aprove == false).ToList();
            if (x == null)
            {
                return null;
            }
            foreach (var item in x)
            {
                UserFrindDTo f
                    = new UserFrindDTo();
                f.FrindsId_fk = item.FrindsId_fk;
                f.User = db.User.Find(item.FrindsId_fk);
                list.Add(f);
            }
            return list;
        }
        public void DeleteFrinds(string id, string MyId)
        {
            FrindsUser frind = db.FrindsUsers.Where(x=>x.FrindsId_fk==id&&x.user_Id==MyId).FirstOrDefault();
           
            db.FrindsUsers.Remove(frind);
            db.SaveChanges();
        }
        #endregion
        #region FollowingUser
        public List<FollowingUserDTo> UserFollowing(string id)
        {
            List<FollowingUserDTo> list = new List<FollowingUserDTo>();
            var x = db.FollowingUsers.Where(x => x.user_Id == id ).ToList();
            if (x == null)
            {
                return null;
            }
            foreach (var item in x)
            {
                FollowingUserDTo f
                    = new FollowingUserDTo();
                f.FrindsId_fk = item.FollowinguseId_fk;
                f.User = db.User.Find(item.FollowinguseId_fk);
                list.Add(f);
            }
            return list;
        }
       
        public void Deletefollwing(string id,string MyId) 
        {
                FollowingUser frind = db.FollowingUsers.Where(x=>x.FollowinguseId_fk==id&&x.user_Id==MyId).FirstOrDefault();
            db.FollowingUsers.Remove(frind);
            db.SaveChanges();
        }
        #endregion
        #region Notification
        public void AddNotification(Notficiation notficiation)
        {
            db.Notficiations.Add(notficiation);
        }
        public List<Notficiation> GetUserNetfcation(string id)
        {
            //var x;
           // List<Notficiation> list = new List<Notficiation>();
            var x = db.Notficiations.Where(x => x.UserId == id && x.Seen == false).ToList();
            if (x == null)
            {
                return null;
            }
            
            return x;
        }
        public void UpdateNetfcation(string id)
        {
            //var x;
            // List<Notficiation> list = new List<Notficiation>();
            var x = db.Notficiations.Find(id);
            if (x == null)
            {

            }
            else {
                x.Seen = true;
                db.SaveChanges();
            }
            
        }
        #endregion

    }
}
