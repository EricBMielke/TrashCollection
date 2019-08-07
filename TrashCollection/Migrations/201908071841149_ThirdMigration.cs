namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ThirdMigration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "DaysOfTheWeekPickUp", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "DaysOfTheWeekPickUp");
        }
    }
}
