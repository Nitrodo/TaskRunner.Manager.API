using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TaskRunner.Manager.Application.DTOs.Read;
using TaskRunner.Manager.Application.DTOs.Write;
using TaskRunner.Manager.Application.Interfaces;

namespace TaskRunner.Manager.API.Controllers
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private readonly ITaskDefinitionService _taskDefinitionService;
        public TaskController(ITaskDefinitionService taskDefinitionService)
        {
            _taskDefinitionService = taskDefinitionService ?? throw new ArgumentNullException(nameof(taskDefinitionService));
        }

        /// <summary>
        /// Search task by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet("Search/Name/{name}")]
        public ActionResult<ProcessDefinitionReadDTO> SearchProcessByName(string name)
        {
            try
            {
                if (string.IsNullOrEmpty(name))
                {
                    return BadRequest("Name is required");
                }

                var taskDefinition = _taskDefinitionService.FindTaskDefinitionByName(name);

                return Ok(taskDefinition);
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }

        /// <summary>
        /// Search process by ID
        /// </summary>
        /// <returns></returns>
        [HttpPost("Create")]
        public ActionResult CreateProcess([FromBody] TaskDefinitionWriteDTO newTaskDefinition)
        {
            try
            {
                if(newTaskDefinition == null)
                {
                    return BadRequest("Task Definition body is required");
                }

                _taskDefinitionService.CreateNewTask(newTaskDefinition);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }
    }
}
