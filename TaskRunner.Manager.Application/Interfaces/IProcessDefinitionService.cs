using TaskRunner.Manager.Application.DTOs.Read;
using TaskRunner.Manager.Application.DTOs.Write;

namespace TaskRunner.Manager.Application.Interfaces
{
    public interface IProcessDefinitionService
    {
        ProcessDefinitionReadDTO FindProcessDefinitionByName(string name);
        void CreateNewProcess(ProcessDefinitionWriteDTO processDefinition);
    }
}
