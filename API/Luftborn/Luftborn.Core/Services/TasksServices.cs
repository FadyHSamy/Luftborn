using AutoMapper;
using Luftborn.Core.Dtos.TasksDto;
using Luftborn.Core.Entities.Tasks;
using Luftborn.Core.Exceptions;
using Luftborn.Core.Interfaces.IRepository;
using Luftborn.Core.Interfaces.IServices;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luftborn.Core.Services
{
    public class TasksServices : ITasksServices
    {
        private readonly ITasksRepository _tasksRepository;
        private readonly IMapper _mapper;
        private readonly IServiceProvider _serviceProvider;
        public TasksServices(ITasksRepository tasksRepository, IMapper mapper, IServiceProvider serviceProvider)
        {
            _tasksRepository = tasksRepository;
            _mapper = mapper;
            _serviceProvider = serviceProvider;
        }
        public void AddTask(AddTaskRequest addTaskRequest)
        {

            try
            {
                Tasks task = _mapper.Map<Tasks>(addTaskRequest);

                _tasksRepository.AddTask(task);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void DeleteTask(int taskId)
        {
            _tasksRepository.DeleteTask(taskId);
        }

        public List<GetAllTasks> GetAllTasks()
        {
            var tasks = _tasksRepository.GetAllTasks();
            List<GetAllTasks> returnList = _mapper.Map<List<GetAllTasks>>(tasks);
            return returnList;
        }

        public void UpdateTask(UpdateTaskDto updateTaskDto)
        {
            Tasks task = _mapper.Map<Tasks>(updateTaskDto);
            _tasksRepository.UpdateTask(task);

        }
    }
}
