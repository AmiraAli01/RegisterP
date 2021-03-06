namespace ScientificJournals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNotesToAdminAuthorToJunkTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paper_Profreader", "NoteToAuthor", c => c.String());
            AddColumn("dbo.Paper_Profreader", "NoteToAdmin", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Paper_Profreader", "NoteToAdmin");
            DropColumn("dbo.Paper_Profreader", "NoteToAuthor");
        }
    }
}
