using System;
using System.Collections.Generic;
using Idea_Collecting_System.Models;

namespace Idea_Collecting_System.Database_Models
{
    public class Category
    {
        public Category()
        {
            Ideas = new HashSet<Idea>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime ClosureDate { get; set; }
        public DateTime FinalClosureDate { get; set; }
        public int IdeasCount { get; set; }
        public int CommentsCount { get; set; }
        public DateTime CreateDate { get; set; }
        public string ApplicationUserId { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<Idea> Ideas { get; set; }
    }
}