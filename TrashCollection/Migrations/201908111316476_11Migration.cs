namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _11Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "CustomersToPickUp", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "CustomersToPickUp");
        }
    }
}
