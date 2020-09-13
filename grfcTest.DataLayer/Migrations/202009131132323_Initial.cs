namespace grfcTest.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.cars",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Brand = c.String(),
                        Model = c.String(),
                        Number = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.car_work_link",
                c => new
                    {
                        CarId = c.Guid(nullable: false),
                        WorkId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.CarId, t.WorkId })
                .ForeignKey("dbo.cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.works", t => t.WorkId, cascadeDelete: true)
                .Index(t => t.CarId)
                .Index(t => t.WorkId);
            
            CreateTable(
                "dbo.works",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Description = c.String(),
                        Date = c.DateTime(nullable: false),
                        EngineType = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.car_work_link", "WorkId", "dbo.works");
            DropForeignKey("dbo.car_work_link", "CarId", "dbo.cars");
            DropIndex("dbo.car_work_link", new[] { "WorkId" });
            DropIndex("dbo.car_work_link", new[] { "CarId" });
            DropTable("dbo.works");
            DropTable("dbo.car_work_link");
            DropTable("dbo.cars");
        }
    }
}
