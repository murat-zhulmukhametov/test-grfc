using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using grfcTest.DataLayer.Entities.Cars;
using grfcTest.DataLayer.Entities.Works;

namespace grfcTest.DataLayer.Entities.CarWorkLinks
{
    [Table("car_work_link")]
    public class CarWorkLink : IgrfcEntity
    {
        [Key]
        public Guid Id { get; set; }
        public Guid CarId { get; set; }
        public Guid WorkId { get; set; }
        public DateTime Date { get; set; }
        [ForeignKey("CarId")]
        protected virtual Car Car { get; set; }
        [ForeignKey("WorkId")]
        protected virtual Work Work { get; set; }
    }
}