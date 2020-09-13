using System.Collections;
using System.Collections.Generic;

namespace grfcTest.Models.Cars.List
{
    public class CarListModel
    {
        public List<CarListItemModel> Cars { get; set; }

        public CarListModel(List<CarListItemModel> cars)
        {
            Cars = cars;
        }
    }
}