namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FourthMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "OneDayPickUp", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "OneDayPickUp");
        }
    }
}
