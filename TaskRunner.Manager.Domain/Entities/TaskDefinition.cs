using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskRunner.Manager.Domain.Entities
{
    public class TaskDefinition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int TaskId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public required string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(250)")]
        public required string Description { get; set; }

        [Required]
        public required bool IsActive { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public required ICollection<ProcessDefinition> ProcessDefinitions { get; set; }

        //public required ICollection<TaskProgress> TaskProgresses { get; set; }

    }
}
