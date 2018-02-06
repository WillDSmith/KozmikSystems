namespace KozmikSystems.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedImagePathColumnToEmployeeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "ImagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "ImagePath");
        }
    }
}
