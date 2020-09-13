using System;
using System.Collections.Generic;
using grfcTest.DataLayer.Common;

namespace grfcTest.Models.Cars.Item
{
    public class CarItemModel
    {
        public Guid Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Number { get; set; }
        public EngineType EngineType { get; set; }
        public List<CarWorkItemModel> Works { get; set; }

        public CarItemModel(Guid id, string brand, string model, string number, EngineType engineType, List<CarWorkItemModel> works)
        {
            Id = id;
            Brand = brand;
            Model = model;
            Number = number;
            Works = works;
            EngineType = engineType;
        }
    }
}