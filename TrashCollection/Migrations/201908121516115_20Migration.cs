namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _20Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PickUpDone", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "PickUpDone");
        }
    }
}
