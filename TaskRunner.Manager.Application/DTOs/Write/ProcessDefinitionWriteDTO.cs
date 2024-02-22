namespace TaskRunner.Manager.Application.DTOs.Write
{
    public class ProcessDefinitionWriteDTO
    {
        public int ProcessId { get; set; }

        public int TaskId { get; set; }

        public required string Name { get; set; }

        public required string Description { get; set; }

        public required bool IsActive { get; set; }

        public required string FunctionName { get; set; }

        public required bool IsRetryAllowed { get; set; }

        public required int Position { get; set; }
    }
}
