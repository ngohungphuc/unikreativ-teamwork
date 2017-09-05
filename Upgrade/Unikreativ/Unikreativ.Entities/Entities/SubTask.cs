using System.Collections.Generic;

namespace Unikreativ.Entities.Entities
{
    public class SubTask : BaseEntity
    {
        public string SubTaskName { get; set; }
        public Project Project { get; set; }
        public IList<TasksRequest> TasksRequests { get; set; }
    }
}