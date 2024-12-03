using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SocialConnect.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Repository.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext()
        {
        }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole() { Name= "Admin" ,NormalizedName="ADMIN"},
                new IdentityRole() { Name = "User", NormalizedName = "USER" });
        }
        public virtual DbSet<User> User { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }
        public virtual DbSet<CommentReact> ComsmentReact { get; set; }
        public virtual DbSet<Message> Massages { get; set; }
        public virtual DbSet<FrindsUser> FrindsUsers { get; set; }
        public virtual DbSet<Notficiation> Notficiations { get; set; }

        
        public virtual DbSet<massageReact> massageReacts { get; set; }
        public virtual DbSet<React> React { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<postReacts> postReacts { get; set; }
        public virtual DbSet<SavedPost> SavedPosts { get; set; }
        public virtual DbSet<FollowingUser> FollowingUsers { get; set; }



        // Add DbSets here!
    }
}
