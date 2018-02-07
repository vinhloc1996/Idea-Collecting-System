using System;
using System.Collections.Generic;
using Idea_Collecting_System.Models;

namespace Idea_Collecting_System.Database_Models
{
    public class Department
    {
        public Department()
        {
            ApplicationUsers = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public DateTime DateAdded { get; set; }
        public int StudentsCount { get; set; }
        public int StaffsCount { get; set; }

        public ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}