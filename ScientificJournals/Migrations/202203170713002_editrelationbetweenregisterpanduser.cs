namespace ScientificJournals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class editrelationbetweenregisterpanduser : DbMigration
    {
        public override void Up()
        {
           

            RenameColumn(table: "dbo.RegisterPs", name: "ApplicationUser_Id", newName: "ApplicationUserId");
            RenameIndex(table: "dbo.RegisterPs", name: "IX_ApplicationUser_Id", newName: "IX_ApplicationUserId");
           
        }
        
        public override void Down()
        {
           
           
            RenameIndex(table: "dbo.RegisterPs", name: "IX_ApplicationUserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.RegisterPs", name: "ApplicationUserId", newName: "ApplicationUser_Id");
           
        }
    }
}
