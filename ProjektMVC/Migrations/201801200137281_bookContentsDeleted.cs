namespace ProjektMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class bookContentsDeleted : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Books", "contents");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Books", "contents", c => c.String());
        }
    }
}
