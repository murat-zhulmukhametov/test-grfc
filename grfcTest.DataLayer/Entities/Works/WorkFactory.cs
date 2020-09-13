using System;
using grfcTest.DataLayer.Common;

namespace grfcTest.DataLayer.Entities.Works
{
    public class WorkFactory : IWorkFactory
    {
        public Work Create(string description, EngineType engineType)
        {
            return new Work()
            {
                Id = Guid.NewGuid(),
                Description = description,
                EngineType = engineType
            };
        }
    }
}