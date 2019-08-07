namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "ZipCode", c => c.String());
            AddColumn("dbo.Customers", "PickUpStartDateSuspend", c => c.String());
            AddColumn("dbo.Customers", "PickUpEndDateSuspend", c => c.String());
            DropColumn("dbo.Customers", "Integer");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Integer", c => c.String());
            DropColumn("dbo.Customers", "PickUpEndDateSuspend");
            DropColumn("dbo.Customers", "PickUpStartDateSuspend");
            DropColumn("dbo.Customers", "ZipCode");
        }
    }
}
