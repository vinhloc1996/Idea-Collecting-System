using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Idea_Collecting_System.Models;

namespace Idea_Collecting_System.Database_Models
{
    public class Summary
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public int TotalIdea { get; set; }
        public int TotalComment { get; set; }
        public int TotalReply { get; set; }
        public int TotalThumbUp { get; set; }
        public int TotalThumbDown { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}