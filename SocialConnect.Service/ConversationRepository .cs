using SocialConnect.Core.Models;
using SocialConnect.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Service
{
   public class ConversationRepository<T> : GenericRepository<Message>
    {
        public ConversationRepository(ApplicationDbContext db) : base(db)
        {
        }
        public List<Message> GetUserConversations(string MyId, string userId)
        {
            
            return db.Massages.Where((m =>( m.SenderId == MyId && m.ReceiverId == userId)||(m.SenderId==userId&&m.ReceiverId == MyId))).ToList();
        }

        public void AddMessage(Message message)
        {
            db.Set<Message>().Add(message);  // This is equivalent to the base Add method
        }
    }
}
