using System;

namespace grfcTest.Models.Cars.Delete
{
    public interface ICarDeleteHandler
    {
        void HandleDelete(Guid id);
    }
}