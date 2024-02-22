using TaskRunner.Manager.API.DTOs.Read;
using TaskRunner.Manager.API.DTOs.Write;

namespace TaskRunner.Manager.Application.Interfaces
{
    public interface IProcessDefinitionService
    {
        ProcessDefinitionReadDTO FindProcessDefinitionByName(string name);
        void CreateNewProcess(int taskId, ProcessDefinitionWriteDTO processDefinitionWriteDTO);
    }
}
