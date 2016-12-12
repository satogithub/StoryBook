namespace UserStory.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        GroupID = c.Int(nullable: false, identity: true),
                        GroupName = c.String(),
                        GroupDescription = c.String(),
                    })
                .PrimaryKey(t => t.GroupID);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        StoryID = c.Int(nullable: false, identity: true),
                        StoryTitle = c.String(),
                        StoryDescription = c.String(),
                        StoryContent = c.String(),
                        PostedOn = c.DateTime(nullable: false),
                        StoryAuthor_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.StoryID)
                .ForeignKey("dbo.Users", t => t.StoryAuthor_UserID)
                .Index(t => t.StoryAuthor_UserID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserID);
            
            CreateTable(
                "dbo.StoryGroups",
                c => new
                    {
                        Story_StoryID = c.Int(nullable: false),
                        Group_GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Story_StoryID, t.Group_GroupID })
                .ForeignKey("dbo.Stories", t => t.Story_StoryID, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group_GroupID, cascadeDelete: true)
                .Index(t => t.Story_StoryID)
                .Index(t => t.Group_GroupID);
            
            CreateTable(
                "dbo.UserGroups",
                c => new
                    {
                        User_UserID = c.Int(nullable: false),
                        Group_GroupID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_UserID, t.Group_GroupID })
                .ForeignKey("dbo.Users", t => t.User_UserID, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.Group_GroupID, cascadeDelete: true)
                .Index(t => t.User_UserID)
                .Index(t => t.Group_GroupID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stories", "StoryAuthor_UserID", "dbo.Users");
            DropForeignKey("dbo.UserGroups", "Group_GroupID", "dbo.Groups");
            DropForeignKey("dbo.UserGroups", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.StoryGroups", "Group_GroupID", "dbo.Groups");
            DropForeignKey("dbo.StoryGroups", "Story_StoryID", "dbo.Stories");
            DropIndex("dbo.UserGroups", new[] { "Group_GroupID" });
            DropIndex("dbo.UserGroups", new[] { "User_UserID" });
            DropIndex("dbo.StoryGroups", new[] { "Group_GroupID" });
            DropIndex("dbo.StoryGroups", new[] { "Story_StoryID" });
            DropIndex("dbo.Stories", new[] { "StoryAuthor_UserID" });
            DropTable("dbo.UserGroups");
            DropTable("dbo.StoryGroups");
            DropTable("dbo.Users");
            DropTable("dbo.Stories");
            DropTable("dbo.Groups");
        }
    }
}
