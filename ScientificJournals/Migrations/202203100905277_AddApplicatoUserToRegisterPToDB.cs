namespace ScientificJournals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddApplicatoUserToRegisterPToDB : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RegisterPs", "ApplicationUser_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.RegisterPs", "ApplicationUser_Id");
            AddForeignKey("dbo.RegisterPs", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RegisterPs", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.RegisterPs", new[] { "ApplicationUser_Id" });
            DropColumn("dbo.RegisterPs", "ApplicationUser_Id");
        }
    }
}
