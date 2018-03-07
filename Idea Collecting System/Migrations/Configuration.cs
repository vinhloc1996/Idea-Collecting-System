using Idea_Collecting_System.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Idea_Collecting_System.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Idea_Collecting_System.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Idea_Collecting_System.Models.ApplicationDbContext context)
        {
            var adminRole = new IdentityRole { Name = "Admin" };
            //Seed role
            if (!context.Roles.Any(r => r.Name == "Admin"))
            {
                var qacRole = new IdentityRole {Name = "QAC"};
                var qamRole = new IdentityRole {Name = "QAM"};

                context.Roles.Add(adminRole);
                context.Roles.Add(qacRole);
                context.Roles.Add(qamRole);
            }
            //Seed user
            if (!context.Users.Any(r => r.UserName == "admin@idc.com"))
            {
                var user = new ApplicationUser
                {
                    UserName = "admin@idc.com",
                    Email = "admin@idc.com",
                    PasswordHash = new PasswordHasher().HashPassword("123456"),
                    SecurityStamp = Guid.NewGuid().ToString()
                };
                var userRole = new IdentityUserRole
                {
                    RoleId = adminRole.Id,
                    UserId = user.Id
                };

                user.Roles.Add(userRole);
                context.Users.Add(user);
            }
        }
    }
}