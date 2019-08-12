namespace TrashCollection.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _21Migration : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.EmployeesTodays");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.EmployeesTodays",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerFirstName = c.String(),
                        CustomerLastName = c.String(),
                        PickUpDone = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
