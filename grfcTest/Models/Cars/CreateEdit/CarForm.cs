using System.Collections.Generic;
using grfcTest.DataLayer.Common;

namespace grfcTest.Models.Cars.CreateEdit
{
    public class CarForm
    {
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }
        public EngineType EngineType { get; set; }
        public IList<CarWorkForm> Works { get; set; }

        public CarForm()
        {
            Works = new List<CarWorkForm>();
        }
    }
}