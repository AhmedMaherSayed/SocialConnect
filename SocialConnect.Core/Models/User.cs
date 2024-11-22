﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialConnect.Core.Models
{
    public class User :IdentityUser
    {
        public string Photo { get; set; }
        public string ProfileURL { get; set; }
        public virtual List<Post> posts { get; set; } = new List<Post>();

        public virtual List<Comment> comments { get; set; } = new List<Comment>();
        public virtual List<postReacts> PostReacts { get; set; } = new List<postReacts>();
        public virtual List<CommentReact> CommentReacts { get; set; } = new List<CommentReact>();
        //public virtual List<FollowingUser> FollowingUsers { get; set; } = new List<FollowingUser>();
        public virtual List<SavedPost> SavedPosts { get; set; } = new List<SavedPost>();
        public virtual List<Massage> Massages { get; set; } = new List<Massage>();
        public virtual List<massageReact> massageReact { get; set; } = new List<massageReact>();







    }
}
