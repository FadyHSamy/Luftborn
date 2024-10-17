using AutoMapper;
using Luftborn.Core.Dtos.TasksDto;
using Luftborn.Core.Entities.TasksEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Luftborn.Core.Mappers.TaskMappers
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<TasksEntity, AddTaskRequest>()
                .ReverseMap();
            CreateMap<TasksEntity, GetAllTasks>()
                .ReverseMap();
            CreateMap<TasksEntity, UpdateTaskDto>()
                .ReverseMap();
        }
    }
}
