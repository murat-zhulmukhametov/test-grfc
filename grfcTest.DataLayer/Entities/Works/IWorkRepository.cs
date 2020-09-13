using System;
using System.Collections.Generic;
using grfcTest.DataLayer.Common;

namespace grfcTest.DataLayer.Entities.Works
{
    public interface IWorkRepository
    {
        IList<Work> All();
        IList<Work> GetByIds(IEnumerable<Guid> ids);
        IList<Work> GetByEngine(EngineType type);
        Work Find(Guid id);
    }
}