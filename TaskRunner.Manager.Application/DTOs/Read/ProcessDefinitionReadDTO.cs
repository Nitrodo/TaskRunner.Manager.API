
namespace TaskRunner.Manager.Application.DTOs.Read
{
    public class ProcessDefinitionReadDTO
    {
        public int ProcessId { get; set; }

        public int TaskId { get;set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public string? FunctionName { get; set; }

        public bool IsRetryAllowed { get; set; }

        public int Position { get; set; }

        public DateTime CreatedDateTime { get; set; }
    }
}
