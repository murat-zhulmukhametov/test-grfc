using grfcTest.DataLayer.Common;

namespace grfcTest.DataLayer.Entities.Works
{
    public interface IWorkFactory
    {
        Work Create(string description, EngineType engineType);
    }
}