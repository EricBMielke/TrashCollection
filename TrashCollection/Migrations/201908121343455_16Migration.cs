namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16Migration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmployeesTodays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerFirstName = c.String(),
                        CustomerLastName = c.String(),
                        Checked = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmployeesTodays");
        }
    }
}
