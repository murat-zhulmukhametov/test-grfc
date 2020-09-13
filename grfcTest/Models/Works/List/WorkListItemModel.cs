using System;
using grfcTest.DataLayer.Common;

namespace grfcTest.Models.Works.List
{
    public class WorkListItemModel
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public EngineType EngineType { get; set; }
    }
}