using System;
using System.Collections.Generic;
using Idea_Collecting_System.Models;

namespace Idea_Collecting_System.Database_Models
{
    public class Idea
    {
        public Idea()
        {
            Comments = new HashSet<Comment>();
            ApplicationUsers = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string Content { get; set; }
        public bool? IsAnonymous { get; set; }
        public bool? IsDisabled { get; set; }
        public int ViewsCount { get; set; }
        public int UpsCount { get; set; }
        public int CategoryId { get; set; }
        public int DownsCount { get; set; }
        public int CommentsCount { get; set; }
        public DateTime LastTimeUpdate { get; set; }
        public string ApplicationUserId { get; set; }

        public Category Category { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
        public ICollection<IdeaState> IdeaStates { get; set; }
    }
}