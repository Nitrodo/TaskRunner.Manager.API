using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskRunner.Manager.Application.Entities
{
    public class ProcessDefinition
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int ProcessId { get; set; }

        // Foreign key
        [Required]
        public int TaskId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public required string Name { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public required string Description { get; set; }

        [Required]
        public required bool IsActive { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(500)")]
        public required string FunctionName { get; set; }

        [Required]
        public required bool IsRetryAllowed { get; set; }

        [Required]
        public required int Position { get; set; }

        public DateTime CreatedDateTime { get; set; }

        [ForeignKey("TaskId")]
        public required TaskDefinition TaskDefinition { get; set; }

        public required ICollection<ProcessProgress> ProcessProgresses { get; set; }
    }
}
