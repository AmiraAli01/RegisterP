namespace ScientificJournals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddKeyWordsToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.KeywordSearches",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfKeywordSearch = c.String(),
                        IdPaper_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RegisterPs", t => t.IdPaper_Id)
                .Index(t => t.IdPaper_Id);
            
            AddColumn("dbo.Papers", "KeywordSearch_Id", c => c.Int());
            CreateIndex("dbo.Papers", "KeywordSearch_Id");
            AddForeignKey("dbo.Papers", "KeywordSearch_Id", "dbo.KeywordSearches", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Papers", "KeywordSearch_Id", "dbo.KeywordSearches");
            DropForeignKey("dbo.KeywordSearches", "IdPaper_Id", "dbo.RegisterPs");
            DropIndex("dbo.Papers", new[] { "KeywordSearch_Id" });
            DropIndex("dbo.KeywordSearches", new[] { "IdPaper_Id" });
            DropColumn("dbo.Papers", "KeywordSearch_Id");
            DropTable("dbo.KeywordSearches");
        }
    }
}
