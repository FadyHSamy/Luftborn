using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luftborn.Core.Dtos.TasksDto
{
    public class GetAllTasks
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TaskStatus Status { get; set; }
    }
}
