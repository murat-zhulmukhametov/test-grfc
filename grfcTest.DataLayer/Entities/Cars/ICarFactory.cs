using grfcTest.DataLayer.Common;

namespace grfcTest.DataLayer.Entities.Cars
{
    public interface ICarFactory
    {
        Car Create(string brand, string model, string number, EngineType engineType);
    }
}