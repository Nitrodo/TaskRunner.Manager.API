namespace TaskRunner.Manager.Application.DTOs.Write
{
    public class TaskDefinitionWriteDTO
    {
        public int TaskId { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public bool IsActive { get; set; }
    }
}
