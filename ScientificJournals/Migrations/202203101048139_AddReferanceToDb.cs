namespace ScientificJournals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddReferanceToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Refrences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfRefrences = c.String(),
                        Paper_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Papers", t => t.Paper_Id)
                .Index(t => t.Paper_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Refrences", "Paper_Id", "dbo.Papers");
            DropIndex("dbo.Refrences", new[] { "Paper_Id" });
            DropTable("dbo.Refrences");
        }
    }
}
