using System;
using Idea_Collecting_System.Models;

namespace Idea_Collecting_System.Database_Models
{
    public class Forum
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime ClosureDate { get; set; }
        public DateTime FinalClosureDate { get; set; }
        public int ThreadsCount { get; set; }
        public int PostsCount { get; set; }
        public DateTime CreateDate { get; set; }
        public ApplicationUser CreateBy { get; set; }
    }
}