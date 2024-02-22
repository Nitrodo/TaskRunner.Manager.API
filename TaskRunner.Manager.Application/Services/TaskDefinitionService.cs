using AutoMapper;
using TaskRunner.Manager.Application.DTOs.Read;
using TaskRunner.Manager.Application.DTOs.Write;
using TaskRunner.Manager.Domain.Entities;
using TaskRunner.Manager.Application.Interfaces;
using TaskRunner.Manager.Infrastructure.Persitence.Interfaces;

namespace TaskRunner.Manager.Application.Services
{
    public class TaskDefinitionService : ITaskDefinitionService
    {
        private readonly IRepository<TaskDefinition> _taskDefinitionRepository;
        private readonly IMapper _mapper;
        public TaskDefinitionService(IRepository<TaskDefinition> taskDefinitionRepository, IMapper mapper)
        {
            _taskDefinitionRepository = taskDefinitionRepository ?? throw new ArgumentNullException(nameof(taskDefinitionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // Get task by name
        public TaskDefinitionReadDTO FindTaskDefinitionByName(string name)
        {
            var taskDefinition = _taskDefinitionRepository.Find(x => x.Name.Contains(name));

            if (taskDefinition == null)
            {
                throw new Exception("Task definition not found");
            }

            return _mapper.Map<TaskDefinitionReadDTO>(taskDefinition);
        }

        // Create a new task
        public void CreateNewTask(TaskDefinitionWriteDTO taskDefinitionWriteDTO)
        {
            var mappedTaskDefinition = _mapper.Map<TaskDefinition>(taskDefinitionWriteDTO);

            _taskDefinitionRepository.Insert(mappedTaskDefinition);
            _taskDefinitionRepository.SaveChanges();
        }
    }
}
