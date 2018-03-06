namespace Idea_Collecting_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Role",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.UserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Role", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FullName = c.String(),
                        Address = c.String(),
                        DoB = c.DateTime(nullable: false, storeType: "date"),
                        Gender = c.Boolean(),
                        DepartmentId = c.Int(),
                        IsDisabled = c.Boolean(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                        Idea_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Idea", t => t.Idea_Id)
                .ForeignKey("dbo.Department", t => t.DepartmentId)
                .Index(t => t.DepartmentId)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.Idea_Id);
            
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        ClosureDate = c.DateTime(nullable: false),
                        FinalClosureDate = c.DateTime(nullable: false),
                        IdeasCount = c.Int(nullable: false),
                        CommentsCount = c.Int(nullable: false),
                        CreateDate = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.Idea",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        IsAnonymous = c.Boolean(),
                        IsDisabled = c.Boolean(),
                        ViewsCount = c.Int(nullable: false),
                        UpsCount = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                        DownsCount = c.Int(nullable: false),
                        CommentsCount = c.Int(nullable: false),
                        LastTimeUpdate = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.ApplicationUserId)
                .ForeignKey("dbo.Category", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.ApplicationUser_Id)
                .Index(t => t.CategoryId)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.Comment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        CreateDate = c.DateTime(nullable: false),
                        Content = c.String(),
                        IsAnonymous = c.Boolean(),
                        IsHidden = c.Boolean(),
                        IsStaff = c.Boolean(),
                        IdeaId = c.Int(nullable: false),
                        LastTimeUpdate = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.ApplicationUserId)
                .ForeignKey("dbo.Idea", t => t.IdeaId, cascadeDelete: true)
                .Index(t => t.IdeaId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.IdeaState",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        IdeaId = c.Int(nullable: false),
                        IsThumbUp = c.Boolean(),
                    })
                .PrimaryKey(t => new { t.ApplicationUserId, t.IdeaId })
                .ForeignKey("dbo.User", t => t.ApplicationUserId, cascadeDelete: true)
                .ForeignKey("dbo.Idea", t => t.IdeaId, cascadeDelete: true)
                .Index(t => t.ApplicationUserId)
                .Index(t => t.IdeaId);
            
            CreateTable(
                "dbo.UserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Department",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Address = c.String(),
                        DateAdded = c.DateTime(nullable: false),
                        StudentsCount = c.Int(nullable: false),
                        StaffsCount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserLogin",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Summary",
                c => new
                    {
                        ApplicationUserId = c.String(nullable: false, maxLength: 128),
                        TotalIdea = c.Int(nullable: false),
                        TotalComment = c.Int(nullable: false),
                        TotalReply = c.Int(nullable: false),
                        TotalThumbUp = c.Int(nullable: false),
                        TotalThumbDown = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ApplicationUserId)
                .ForeignKey("dbo.User", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Summary", "ApplicationUserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "UserId", "dbo.User");
            DropForeignKey("dbo.UserLogin", "UserId", "dbo.User");
            DropForeignKey("dbo.Idea", "ApplicationUser_Id", "dbo.User");
            DropForeignKey("dbo.User", "DepartmentId", "dbo.Department");
            DropForeignKey("dbo.UserClaim", "UserId", "dbo.User");
            DropForeignKey("dbo.IdeaState", "IdeaId", "dbo.Idea");
            DropForeignKey("dbo.IdeaState", "ApplicationUserId", "dbo.User");
            DropForeignKey("dbo.Comment", "IdeaId", "dbo.Idea");
            DropForeignKey("dbo.Comment", "ApplicationUserId", "dbo.User");
            DropForeignKey("dbo.Idea", "CategoryId", "dbo.Category");
            DropForeignKey("dbo.User", "Idea_Id", "dbo.Idea");
            DropForeignKey("dbo.Idea", "ApplicationUserId", "dbo.User");
            DropForeignKey("dbo.Category", "ApplicationUserId", "dbo.User");
            DropForeignKey("dbo.UserRole", "RoleId", "dbo.Role");
            DropIndex("dbo.Summary", new[] { "ApplicationUserId" });
            DropIndex("dbo.UserLogin", new[] { "UserId" });
            DropIndex("dbo.UserClaim", new[] { "UserId" });
            DropIndex("dbo.IdeaState", new[] { "IdeaId" });
            DropIndex("dbo.IdeaState", new[] { "ApplicationUserId" });
            DropIndex("dbo.Comment", new[] { "ApplicationUserId" });
            DropIndex("dbo.Comment", new[] { "IdeaId" });
            DropIndex("dbo.Idea", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Idea", new[] { "ApplicationUserId" });
            DropIndex("dbo.Idea", new[] { "CategoryId" });
            DropIndex("dbo.Category", new[] { "ApplicationUserId" });
            DropIndex("dbo.User", new[] { "Idea_Id" });
            DropIndex("dbo.User", "UserNameIndex");
            DropIndex("dbo.User", new[] { "DepartmentId" });
            DropIndex("dbo.UserRole", new[] { "RoleId" });
            DropIndex("dbo.UserRole", new[] { "UserId" });
            DropIndex("dbo.Role", "RoleNameIndex");
            DropTable("dbo.Summary");
            DropTable("dbo.UserLogin");
            DropTable("dbo.Department");
            DropTable("dbo.UserClaim");
            DropTable("dbo.IdeaState");
            DropTable("dbo.Comment");
            DropTable("dbo.Idea");
            DropTable("dbo.Category");
            DropTable("dbo.User");
            DropTable("dbo.UserRole");
            DropTable("dbo.Role");
        }
    }
}
