namespace grfcTest.DataLayer.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<grfcTest.DataLayer.grfcDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(grfcTest.DataLayer.grfcDbContext context)
        {
            // seed
        }
    }
}
