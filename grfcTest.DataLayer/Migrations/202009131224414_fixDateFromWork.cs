namespace grfcTest.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixDateFromWork : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.car_work_link", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.works", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.works", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.car_work_link", "Date");
        }
    }
}
