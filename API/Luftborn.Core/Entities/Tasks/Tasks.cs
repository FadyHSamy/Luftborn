using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luftborn.Core.Entities.Tasks
{
    public enum TaskStatus
    {
        Unfinished = 0,
        Finished = 1
    }
    public class Tasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TaskStatus Status { get; set; }
    }
}
