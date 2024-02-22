using Microsoft.AspNetCore.Mvc;
using TaskRunner.Manager.Application.DTOs.Read;
using TaskRunner.Manager.Application.DTOs.Write;
using TaskRunner.Manager.Application.Interfaces;

namespace TaskRunner.Manager.API.Controllers
{
    [ApiVersion("1")]
    [Route("v{version:apiVersion}/[controller]")]
    [ApiController]
    public class ProcessController : ControllerBase
    {
        private readonly IProcessDefinitionService _processDefinitionService;
        public ProcessController(IProcessDefinitionService processDefinitionService)
        {
            _processDefinitionService = processDefinitionService ?? throw new ArgumentNullException(nameof(processDefinitionService));
        }

        /// <summary>
        /// Search process by name
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

                var processDefinition = _processDefinitionService.FindProcessDefinitionByName(name);

                return Ok(processDefinition);
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
        public ActionResult CreateProcess([FromBody] ProcessDefinitionWriteDTO newProcessDefinition)
        {
            try
            {
                _processDefinitionService.CreateNewProcess(newProcessDefinition);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest($"{e.Message}");
            }
        }
    }
}