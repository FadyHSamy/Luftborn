using Luftborn.Core.Dtos.TasksDto;
using Luftborn.Core.Entities.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luftborn.Core.Interfaces.IServices
{
    public interface ITasksServices
    {
        void AddTask(AddTaskRequest addTaskRequest);
        List<GetAllTasks> GetAllTasks();
        void DeleteTask(int taskId);
        void UpdateTask(UpdateTaskDto updateTaskDto);
    }
}
