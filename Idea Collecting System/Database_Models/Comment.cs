using System;
using Idea_Collecting_System.Models;

namespace Idea_Collecting_System.Database_Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDate { get; set; }
        public string Content { get; set; }
        public bool? IsAnonymous { get; set; }
        public bool? IsHidden { get; set; }
        public bool? IsStaff { get; set; }
        public int IdeaId { get; set; }
        public DateTime LastTimeUpdate { get; set; }
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Idea Idea { get; set; }
    }
}