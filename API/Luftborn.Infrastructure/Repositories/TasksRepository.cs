using Luftborn.Core.Dtos.TasksDto;
using Luftborn.Core.Entities.TasksEntity;
using Luftborn.Core.Exceptions;
using Luftborn.Core.Interfaces.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Luftborn.Infrastructure.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private static List<TasksEntity> AllAvaliableTasks = new List<TasksEntity>();
        private static int nextId = 1;

        public void AddTask(TasksEntity tasks)
        {
            tasks.Id = nextId;
            tasks.Status = Core.Entities.TasksEntity.TaskStatus.Unfinished;
            nextId = nextId + 1;
            AllAvaliableTasks.Add(tasks);
        }

        public void DeleteTask(int taskId)
        {
            AllAvaliableTasks = AllAvaliableTasks.Where(task => task.Id != taskId).ToList();
        }

        public List<TasksEntity> GetAllTasks()
        {
            return AllAvaliableTasks;
        }

        public void UpdateTask(TasksEntity tasks)
        {
            var existingTask = AllAvaliableTasks.FirstOrDefault(task => task.Id == tasks.Id);
            if (existingTask == null)
            {
                throw new NotFoundException("This Task Not Found");
            }
            existingTask.Status = tasks.Status;
        }
    }
}
