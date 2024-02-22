using TaskRunner.Manager.Application.DTOs.Read;
using TaskRunner.Manager.Application.DTOs.Write;

namespace TaskRunner.Manager.Application.Interfaces
{
    public interface ITaskDefinitionService
    {
        TaskDefinitionReadDTO FindTaskDefinitionByName(string name);
        void CreateNewTask(TaskDefinitionWriteDTO taskDefinitionWriteDTO);
    }
}
