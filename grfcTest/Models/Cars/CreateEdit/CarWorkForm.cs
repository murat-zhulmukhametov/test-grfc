using System;

namespace grfcTest.Models.Cars.CreateEdit
{
    public class CarWorkForm
    {
        public Guid Id { get; set; }
        public Guid WorkId { get; set; }
        public DateTime Date { get; set; }
    }
}