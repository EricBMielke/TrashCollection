namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _18Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeesTodays", "PickUpDone", c => c.Boolean(nullable: false));
            DropColumn("dbo.EmployeesTodays", "Checked");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeesTodays", "Checked", c => c.Boolean(nullable: false));
            DropColumn("dbo.EmployeesTodays", "PickUpDone");
        }
    }
}
