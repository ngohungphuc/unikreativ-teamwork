using System;
using System.Collections.Generic;
using System.Text;

namespace Unikreativ.Entities.Entities
{
    public class SubTask : BaseEntity
    {
        public string SubTaskName { get; set; }
        public Project Project { get; set; }
        public ICollection<TasksRequest> TasksRequests { get; set; }
    }
}