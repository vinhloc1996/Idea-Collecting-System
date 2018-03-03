namespace Idea_Collecting_System.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTablesName : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Categories", newName: "Category");
            RenameTable(name: "dbo.Ideas", newName: "Idea");
            RenameTable(name: "dbo.Comments", newName: "Comment");
            RenameTable(name: "dbo.IdeaStates", newName: "IdeaState");
            RenameTable(name: "dbo.Departments", newName: "Department");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Department", newName: "Departments");
            RenameTable(name: "dbo.IdeaState", newName: "IdeaStates");
            RenameTable(name: "dbo.Comment", newName: "Comments");
            RenameTable(name: "dbo.Idea", newName: "Ideas");
            RenameTable(name: "dbo.Category", newName: "Categories");
        }
    }
}
