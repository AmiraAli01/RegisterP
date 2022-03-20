namespace ScientificJournals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRegisterPToDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RegisterPs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ISSN = c.Int(nullable: false),
                        Major = c.String(),
                        Origination = c.String(),
                        IsEditor = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RegisterPs");
        }
    }
}
