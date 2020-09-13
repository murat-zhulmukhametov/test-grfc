using System.Data.Common;
using System.Data.Entity;
using grfcTest.DataLayer.Entities.Cars;
using grfcTest.DataLayer.Entities.CarWorkLinks;
using grfcTest.DataLayer.Entities.Works;

namespace grfcTest.DataLayer
{
    public class grfcDbContext : DbContext
    {
        public grfcDbContext()
        {
        }

        public grfcDbContext(DbConnection existingConnection, bool contextOwnsConnection) : base(existingConnection,
            contextOwnsConnection)
        {
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Work> Works { get; set; }
        public DbSet<CarWorkLink> CarWorkLinks { get; set; }
    }
}