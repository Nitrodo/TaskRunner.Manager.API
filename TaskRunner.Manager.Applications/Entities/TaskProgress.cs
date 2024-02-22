using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskRunner.Manager.Application.Entities
{
    public class TaskProgress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int TaskProgressId { get; set; }

        // Foreign key
        [Required]
        public int TaskId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public required string Status { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [ForeignKey("TaskId")]
        public required TaskDefinition TaskDefinition { get; set; }

        public required ICollection<ProcessProgress> ProcessProgresses { get; set; }

    }
}
