namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _17Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CurrentlyDue", c => c.Double(nullable: false));
            AddColumn("dbo.EmployeesTodays", "FirstName", c => c.String());
            AddColumn("dbo.EmployeesTodays", "LastName", c => c.String());
            DropColumn("dbo.EmployeesTodays", "CustomerFirstName");
            DropColumn("dbo.EmployeesTodays", "CustomerLastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeesTodays", "CustomerLastName", c => c.String());
            AddColumn("dbo.EmployeesTodays", "CustomerFirstName", c => c.String());
            DropColumn("dbo.EmployeesTodays", "LastName");
            DropColumn("dbo.EmployeesTodays", "FirstName");
            DropColumn("dbo.Customers", "CurrentlyDue");
        }
    }
}
