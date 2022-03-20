namespace ScientificJournals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPaperProfreaderJunkTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Paper_Profreader",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PaperId = c.Int(nullable: false),
                        ProfreaderId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Papers", t => t.PaperId, cascadeDelete: false)
                .ForeignKey("dbo.Profreaders", t => t.ProfreaderId, cascadeDelete: false)
                .Index(t => t.PaperId)
                .Index(t => t.ProfreaderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Paper_Profreader", "ProfreaderId", "dbo.Profreaders");
            DropForeignKey("dbo.Paper_Profreader", "PaperId", "dbo.Papers");
            DropIndex("dbo.Paper_Profreader", new[] { "ProfreaderId" });
            DropIndex("dbo.Paper_Profreader", new[] { "PaperId" });
            DropTable("dbo.Paper_Profreader");
        }
    }
}
