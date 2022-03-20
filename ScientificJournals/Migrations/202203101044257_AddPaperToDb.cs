namespace ScientificJournals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaperToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Papers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Titel = c.String(),
                        Abstract = c.String(),
                        Filepath = c.String(),
                        FileName = c.String(),
                        Status = c.String(),
                        RegisterP_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RegisterPs", t => t.RegisterP_Id)
                .Index(t => t.RegisterP_Id);
            
            CreateTable(
                "dbo.RegisterPs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ISSN = c.Int(nullable: false),
                        Major = c.String(),
                        Origination = c.String(),
                        IsEditor = c.Boolean(nullable: false),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            DropTable("dbo.categories");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            DropForeignKey("dbo.Papers", "RegisterP_Id", "dbo.RegisterPs");
            DropForeignKey("dbo.RegisterPs", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RegisterPs", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Papers", new[] { "RegisterP_Id" });
            DropTable("dbo.RegisterPs");
            DropTable("dbo.Papers");
        }
    }
}
