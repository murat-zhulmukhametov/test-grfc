namespace grfcTest.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactorLinkWorkCar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.car_work_link", "Id", c => c.Guid(nullable: false));
            DropPrimaryKey("dbo.car_work_link");
            AddPrimaryKey("dbo.car_work_link", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.car_work_link");
            AddPrimaryKey("dbo.car_work_link", new[] { "CarId", "WorkId" });
            DropColumn("dbo.car_work_link", "Id");
        }
    }
}
