namespace ScientificJournals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddProfreaderTableToDb2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Profreaders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(maxLength: 128),
                        MajorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Majors", t => t.MajorId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.MajorId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Profreaders", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Profreaders", "MajorId", "dbo.Majors");
            DropIndex("dbo.Profreaders", new[] { "MajorId" });
            DropIndex("dbo.Profreaders", new[] { "UserId" });
            DropTable("dbo.Profreaders");
        }
    }
}
