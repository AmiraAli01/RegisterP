namespace ScientificJournals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddstatusandrejectnotetoJunkTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Paper_Profreader", "Status", c => c.String());
            AddColumn("dbo.Paper_Profreader", "RejectNote", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Paper_Profreader", "RejectNote");
            DropColumn("dbo.Paper_Profreader", "Status");
        }
    }
}
