using Idea_Collecting_System.Models;

namespace Idea_Collecting_System.Database_Models
{
    public class IdeaState
    {
        public string ApplicationUserId { get; set; }
        public int IdeaId { get; set; }
        public bool? IsThumbUp { get; set; }

        public ApplicationUser ApplicationUser { get; set; }
        public Idea Idea { get; set; }
    }
}