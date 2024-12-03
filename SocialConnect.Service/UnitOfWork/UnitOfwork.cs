
using SocialConnect.Core.Models;
using SocialConnect.Repository.Data;
using SocialConnect.Service;
using SocialConnect.Service.UnitOfWork;

namespace SocialConnect.Service
{
    public class UnitOfwork
    {
        ApplicationDbContext db;
        GenericRepository<Post> Postrepository;
        CommentRepository Comment;
        PostRep PostRep;
        FrindAndFolloingAndNotficationUserRep FrindAndFolloingAndNotficationUserRep;
        ConversationRepository<Message> conversationRepository;
        GenericRepository<Comment> Commentrepository;
        GenericRepository<CommentReact> CommentReactsrepository;
        GenericRepository<postReacts> PostReactsrepository;
        GenericRepository<FrindsUser> FrindsUserrepository;
        GenericRepository<FollowingUser> FollowingUserReactsrepository;
        GenericRepository<Notficiation> Notficationrepo ;


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
        public ConversationRepository<Message> Conversations
        {
            get
            {
                if (conversationRepository == null)
                {
                    conversationRepository = new ConversationRepository<Message>(db);
                }
                return conversationRepository;
            }
        }
        public CommentRepository comment
        {
            get
            {
                if (Comment == null)
                {
                    Comment = new CommentRepository(db);
                }
                return Comment;
            }
        }
        public PostRep postRep
        {
            get
            {
                if (PostRep == null)
                {
                    PostRep = new PostRep(db);
                }
                return PostRep;
            }
        }
        public GenericRepository<postReacts> postReactsrepository
        {
            get
            {
                if (Postrepository == null)
                {
                    PostReactsrepository = new GenericRepository<postReacts>(db);
                }
                return PostReactsrepository;
            }
        }
        public GenericRepository<CommentReact> commentReactsrepository
        {
            get
            {
                if (Postrepository == null)
                {
                    CommentReactsrepository = new GenericRepository<CommentReact>(db);
                }
                return CommentReactsrepository;
            }
        }
        public GenericRepository<Comment> commentrepository
        {
            get
            {
                if (Commentrepository == null)
                {
                    Commentrepository = new GenericRepository<Comment>(db);
                }
                return Commentrepository;
            }
        }
        public GenericRepository<FrindsUser> frindsUserrepository
        {
            get
            {
                if (FrindsUserrepository == null)
                {
                    FrindsUserrepository = new GenericRepository<FrindsUser>(db);
                }
                return FrindsUserrepository;
            }
        }
        public GenericRepository<FollowingUser> followingUserReactsrepository
        {
            get
            {
                if (FollowingUserReactsrepository == null)
                {
                    FollowingUserReactsrepository = new GenericRepository<FollowingUser>(db);
                }
                return FollowingUserReactsrepository;
            }
        }
        public GenericRepository<Notficiation> notficationrepo
        {
            get
            {
                if (Notficationrepo == null)
                {
                    Notficationrepo = new GenericRepository<Notficiation>(db);
                }
                return Notficationrepo;
            }
        }

        public FrindAndFolloingAndNotficationUserRep frindAndFolloingAndNotficationUserRep
        {
            get
            {
                if (FrindAndFolloingAndNotficationUserRep == null)
                {
                    FrindAndFolloingAndNotficationUserRep = new FrindAndFolloingAndNotficationUserRep(db);
                }
                return FrindAndFolloingAndNotficationUserRep;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }

    }
}
