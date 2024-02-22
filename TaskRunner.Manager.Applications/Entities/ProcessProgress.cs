using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TaskRunner.Manager.Application.Entities
{
    public class ProcessProgress
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        public int ProcessProgressId { get; set; }

        // Foreign key
        [Required]
        public int TaskProgressId { get; set; }
        
        // Foreign key
        [Required]
        public int ProcessId { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public required string Status { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public DateTime UpdatedDateTime { get; set; }

        [ForeignKey("ProcessId")]
        public required ProcessDefinition ProcessDefinition { get; set; }

        [ForeignKey("TaskProgressId")]
        public required TaskProgress TaskProgress { get; set; }
    }
}
