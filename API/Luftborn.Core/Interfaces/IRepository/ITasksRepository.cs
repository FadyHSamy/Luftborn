using Luftborn.Core.Dtos.TasksDto;
using Luftborn.Core.Entities.TasksEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luftborn.Core.Interfaces.IRepository
{
    public interface ITasksRepository
    {
        void AddTask(TasksEntity tasks);
        List<TasksEntity> GetAllTasks();
        void DeleteTask(int taskId);
        void UpdateTask(TasksEntity tasks);
    }
}
