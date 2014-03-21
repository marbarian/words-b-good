namespace WordsBGood.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuizResultsTable : DbMigration
    {
        public override void Up()
        {
            
            
           
            
            CreateTable(
                "dbo.QuizResults",
                c => new
                    {
                        QuizResultId = c.Int(nullable: false, identity: true),
                        HighScore = c.Int(nullable: false),
                        Category_CategoryId = c.Int(),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.QuizResultId)
                .ForeignKey("dbo.Categories", t => t.Category_CategoryId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.Category_CategoryId)
                .Index(t => t.User_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.QuizResults", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.QuizResults", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Vocabs", "Category_CategoryId", "dbo.Categories");
            DropForeignKey("dbo.Categories", "User_UserId", "dbo.Users");
            DropIndex("dbo.QuizResults", new[] { "User_UserId" });
            DropIndex("dbo.QuizResults", new[] { "Category_CategoryId" });
            DropIndex("dbo.Vocabs", new[] { "Category_CategoryId" });
            DropIndex("dbo.Categories", new[] { "User_UserId" });
            DropTable("dbo.QuizResults");
            DropTable("dbo.Vocabs");
            DropTable("dbo.Users");
            DropTable("dbo.Categories");
        }
    }
}
