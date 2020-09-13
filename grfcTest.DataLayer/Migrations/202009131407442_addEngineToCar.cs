namespace grfcTest.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEngineToCar : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.cars", "EngineType", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.cars", "EngineType");
        }
    }
}
