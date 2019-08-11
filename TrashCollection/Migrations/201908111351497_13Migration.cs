namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _13Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "CustomersToPickUpDuringWeek", c => c.String());
            AddColumn("dbo.Employees", "CustomersToPickUpToday", c => c.String());
            DropColumn("dbo.Employees", "CustomersToPickUp");
            DropColumn("dbo.Employees", "CustomersToPickUpSpecificDay");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "CustomersToPickUpSpecificDay", c => c.String());
            AddColumn("dbo.Employees", "CustomersToPickUp", c => c.String());
            DropColumn("dbo.Employees", "CustomersToPickUpToday");
            DropColumn("dbo.Employees", "CustomersToPickUpDuringWeek");
        }
    }
}
