namespace KozmikSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DeletedStaffsTable : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Staffs");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Staffs",
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
    }
}
