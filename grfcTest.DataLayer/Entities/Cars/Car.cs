using System;
using System.ComponentModel.DataAnnotations.Schema;
using grfcTest.DataLayer.Common;

namespace grfcTest.DataLayer.Entities.Cars
{
    [Table("cars")]
    public class Car : IgrfcEntity
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }
        public EngineType EngineType { get; set; }
    }
}