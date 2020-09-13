using System.Collections.Generic;

namespace grfcTest.Models.Works.List
{
    public class WorkListModel
    {
        public IList<WorkListItemModel> Works { get; set; }

        public WorkListModel(IList<WorkListItemModel> works)
        {
            Works = works;
        }
    }
}