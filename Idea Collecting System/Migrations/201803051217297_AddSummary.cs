namespace Idea_Collecting_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSummary : DbMigration
    {
        public override void Up()
        {
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
            DropIndex("dbo.Summary", new[] { "ApplicationUserId" });
            DropTable("dbo.Summary");
        }
    }
}
