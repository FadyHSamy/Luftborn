using Luftborn.Core.Dtos.TasksDto;
using Luftborn.Core.Entities.Shared;
using Luftborn.Core.Exceptions;
using Luftborn.Core.Interfaces.IServices;
using Luftborn.Core.Utilities.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Luftborn.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TasksController : ControllerBase
    {
        private readonly ITasksServices _taskServices;
        public TasksController(ITasksServices tasksServices)
        {
            _taskServices = tasksServices;
        }
        [HttpPost("AddTask")]
        public async Task<IActionResult> AddTask([FromBody] AddTaskRequest AddTask)
        {
            try
            {
                if (string.IsNullOrEmpty(AddTask.Title)) 
                {
                    throw new ValidationCustomException("Task Title Is Required");
                }
                _taskServices.AddTask(AddTask);
                ApiResponse<object> response = ApiResponseHelper.Success<object>(Request, "Task Is Added Successfully");
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpGet("GetAllTasks")]
        public async Task<IActionResult> GetAllTasks()
        {
            try
            {
                var ListTasks = _taskServices.GetAllTasks();
                ApiResponse<object> response = ApiResponseHelper.Success<object>(Request, "Task Is Fetched Successfully", ListTasks);
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask(UpdateTaskDto updateTaskDto)
        {
            try
            {
                _taskServices.UpdateTask(updateTaskDto);
                ApiResponse<object> response = ApiResponseHelper.Success<object>(Request, "Task Is Updated Successfully");
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
        [HttpDelete("DeleteTask")]
        public async Task<IActionResult> DeleteTask(int TaskId)
        {
            try
            {
                _taskServices.DeleteTask(TaskId);
                ApiResponse<object> response = ApiResponseHelper.Success<object>(Request, "Task Is Deleted Successfully");
                return Ok(response);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
