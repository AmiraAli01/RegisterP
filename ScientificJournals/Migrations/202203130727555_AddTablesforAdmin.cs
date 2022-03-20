namespace ScientificJournals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTablesforAdmin : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.KeywordSearches", name: "Register_Id", newName: "IdPaper_Id");
            RenameColumn(table: "dbo.Papers", name: "Keyword_Id", newName: "KeywordSearch_Id");
            RenameIndex(table: "dbo.KeywordSearches", name: "IX_Register_Id", newName: "IX_IdPaper_Id");
            RenameIndex(table: "dbo.Papers", name: "IX_Keyword_Id", newName: "IX_KeywordSearch_Id");
            CreateTable(
                "dbo.Majors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Volumes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.RegisterPs", "MajorId", c => c.Int(nullable: false));
            AddColumn("dbo.Papers", "VolumeId", c => c.Int(nullable: false));
            AddColumn("dbo.Papers", "MajorId", c => c.Int(nullable: false));
            CreateIndex("dbo.RegisterPs", "MajorId");
            CreateIndex("dbo.Papers", "VolumeId");
            CreateIndex("dbo.Papers", "MajorId");
            AddForeignKey("dbo.Papers", "MajorId", "dbo.Majors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Papers", "VolumeId", "dbo.Volumes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RegisterPs", "MajorId", "dbo.Majors", "Id", cascadeDelete: true);
            DropColumn("dbo.KeywordSearches", "IdRegister");
            DropColumn("dbo.RegisterPs", "Major");
            DropColumn("dbo.RegisterPs", "IdApplicationUser");
            DropColumn("dbo.Papers", "IdRegisterP");
            DropColumn("dbo.Papers", "IdKeyword");
            DropColumn("dbo.Refrences", "IdPaper");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Refrences", "IdPaper", c => c.String());
            AddColumn("dbo.Papers", "IdKeyword", c => c.String());
            AddColumn("dbo.Papers", "IdRegisterP", c => c.Int(nullable: false));
            AddColumn("dbo.RegisterPs", "IdApplicationUser", c => c.String());
            AddColumn("dbo.RegisterPs", "Major", c => c.String());
            AddColumn("dbo.KeywordSearches", "IdRegister", c => c.Int(nullable: false));
            DropForeignKey("dbo.RegisterPs", "MajorId", "dbo.Majors");
            DropForeignKey("dbo.Papers", "VolumeId", "dbo.Volumes");
            DropForeignKey("dbo.Papers", "MajorId", "dbo.Majors");
            DropIndex("dbo.Papers", new[] { "MajorId" });
            DropIndex("dbo.Papers", new[] { "VolumeId" });
            DropIndex("dbo.RegisterPs", new[] { "MajorId" });
            DropColumn("dbo.Papers", "MajorId");
            DropColumn("dbo.Papers", "VolumeId");
            DropColumn("dbo.RegisterPs", "MajorId");
            DropTable("dbo.Volumes");
            DropTable("dbo.Majors");
            RenameIndex(table: "dbo.Papers", name: "IX_KeywordSearch_Id", newName: "IX_Keyword_Id");
            RenameIndex(table: "dbo.KeywordSearches", name: "IX_IdPaper_Id", newName: "IX_Register_Id");
            RenameColumn(table: "dbo.Papers", name: "KeywordSearch_Id", newName: "Keyword_Id");
            RenameColumn(table: "dbo.KeywordSearches", name: "IdPaper_Id", newName: "Register_Id");
        }
    }
}
