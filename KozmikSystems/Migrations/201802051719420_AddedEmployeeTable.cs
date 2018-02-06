namespace KozmikSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedEmployeeTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Position = c.String(),
                        Department = c.String(),
                        DateHired = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
