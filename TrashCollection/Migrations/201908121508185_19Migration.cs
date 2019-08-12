namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _19Migration : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EmployeesTodays", "CustomerFirstName", c => c.String());
            AddColumn("dbo.EmployeesTodays", "CustomerLastName", c => c.String());
            DropColumn("dbo.EmployeesTodays", "FirstName");
            DropColumn("dbo.EmployeesTodays", "LastName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EmployeesTodays", "LastName", c => c.String());
            AddColumn("dbo.EmployeesTodays", "FirstName", c => c.String());
            DropColumn("dbo.EmployeesTodays", "CustomerLastName");
            DropColumn("dbo.EmployeesTodays", "CustomerFirstName");
        }
    }
}
