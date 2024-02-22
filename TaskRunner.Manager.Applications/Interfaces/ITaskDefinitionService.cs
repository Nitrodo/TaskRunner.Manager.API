using TaskRunner.Manager.API.DTOs.Read;
using TaskRunner.Manager.API.DTOs.Write;

namespace TaskRunner.Manager.Application.Interfaces
{
    public interface ITaskDefinitionService
    {
        ProcessDefinitionReadDTO FindTaskDefinitionByName(string name);
        void CreateNewTask(int taskId, ProcessDefinitionWriteDTO processDefinitionWriteDTO);
    }
}
