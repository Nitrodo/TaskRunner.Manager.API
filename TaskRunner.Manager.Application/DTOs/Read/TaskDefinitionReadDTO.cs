using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskRunner.Manager.Application.DTOs.Read
{
    public class TaskDefinitionReadDTO
    {
        public int TaskId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public required IEnumerable<ProcessDefinitionReadDTO> ProcessDefinitions { get; set; }
    }
}
