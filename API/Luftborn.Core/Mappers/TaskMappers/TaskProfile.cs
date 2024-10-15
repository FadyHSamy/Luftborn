using AutoMapper;
using Luftborn.Core.Dtos.TasksDto;
using Luftborn.Core.Entities.Tasks;
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
            CreateMap<Tasks, AddTaskRequest>()
                .ReverseMap();
            CreateMap<Tasks, GetAllTasks>()
                .ReverseMap();
            CreateMap<Tasks, UpdateTaskDto>()
                .ReverseMap();
        }
    }
}
