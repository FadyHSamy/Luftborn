using Luftborn.Core.Dtos.TasksDto;
using Luftborn.Core.Entities.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luftborn.Core.Interfaces.IRepository
{
    public interface ITasksRepository
    {
        void AddTask(Tasks tasks);
        List<Tasks> GetAllTasks();
        void DeleteTask(int taskId);
        void UpdateTask(Tasks tasks);
    }
}
