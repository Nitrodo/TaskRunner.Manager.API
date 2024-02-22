using AutoMapper;
using TaskRunner.Manager.API.DTOs.Read;
using TaskRunner.Manager.API.DTOs.Write;
using TaskRunner.Manager.Application.Entities;
using TaskRunner.Manager.Application.Interfaces;
using TaskRunner.Manager.Infrastructure.Persitence.Interfaces;

namespace TaskRunner.Manager.Application.Services
{
    public class ProcessDefinitionService : IProcessDefinitionService
    {
        private readonly IRepository<ProcessDefinition> _processDefinitionRepository;
        private readonly IMapper _mapper;
        public ProcessDefinitionService(IRepository<ProcessDefinition> processDefinitionRepository, IMapper mapper)
        {
            _processDefinitionRepository = processDefinitionRepository ?? throw new ArgumentNullException(nameof(processDefinitionRepository));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        // Get process by name
        public ProcessDefinitionReadDTO FindProcessDefinitionByName(string name)
        {
            var processDefinition = _processDefinitionRepository.Find(x => x.Name.Contains(name));

            return _mapper.Map<ProcessDefinitionReadDTO>(processDefinition);
        }

        // Create a new process
        public void CreateNewProcess(int taskId, ProcessDefinitionWriteDTO processDefinitionWriteDTO)
        {
            var mappedProcessDefinition = _mapper.Map<ProcessDefinition>(processDefinitionWriteDTO);

            _processDefinitionRepository.Insert(mappedProcessDefinition);
            _processDefinitionRepository.SaveChanges();
        }
    }
}
