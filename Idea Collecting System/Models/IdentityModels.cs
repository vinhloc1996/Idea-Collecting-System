using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Security.Claims;
using System.Threading.Tasks;
using Idea_Collecting_System.Customs;
using Idea_Collecting_System.Database_Models;
using Idea_Collecting_System.Migrations;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Idea_Collecting_System.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Ideas = new HashSet<Idea>();
            Posts = new HashSet<Comment>();
            Categories = new HashSet<Category>();
            IdeaStates = new HashSet<IdeaState>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        public string FullName { get; set; }
        public string Address { get; set; }
        [Column(TypeName = "Date")]
        public DateTime DoB { get; set; }
        public bool? Gender { get; set; }
        public int? DepartmentId { get; set; }
        public bool? IsDisabled { get; set; }

        public Department Department { get; set; }
        public Summary Summary { get; set; }
        public ICollection<Idea> Ideas { get; set; }
        public ICollection<Category> Categories { get; set; }
        public ICollection<Comment> Posts { get; set; }
        public ICollection<IdeaState> IdeaStates { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            //Implement later
//            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
            
//            Database.SetInitializer(new CustomInitializer());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdeaState>().HasKey(i => new
            {
                i.ApplicationUserId,
                i.IdeaId
            });
            modelBuilder.Entity<IdeaState>().HasRequired(i => i.ApplicationUser).WithMany(i => i.IdeaStates)
                .HasForeignKey(i => i.ApplicationUserId);
            modelBuilder.Entity<IdeaState>().HasRequired(i => i.Idea).WithMany(i => i.IdeaStates)
                .HasForeignKey(i => i.IdeaId);

            modelBuilder.Entity<ApplicationUser>().ToTable("User");
            modelBuilder.Entity<IdentityRole>().ToTable("Role");
            modelBuilder.Entity<IdentityUserRole>().ToTable("UserRole");
            modelBuilder.Entity<IdentityUserClaim>().ToTable("UserClaim");
            modelBuilder.Entity<IdentityUserLogin>().ToTable("UserLogin");
            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Category>().ToTable("Category");
            modelBuilder.Entity<Comment>().ToTable("Comment");
            modelBuilder.Entity<Idea>().ToTable("Idea");
            modelBuilder.Entity<IdeaState>().ToTable("IdeaState");
            modelBuilder.Entity<Summary>().ToTable("Summary");
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Department> Department { get; set; }
    }
}