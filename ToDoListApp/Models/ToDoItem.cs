using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Models
{
    public class ToDoItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public required string Title { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        public bool IsCompleted { get; set; }

        [Required]
        public DateTime DueDate { get; set; }

        [Required]
        public int PriorityId { get; set; }
        public Priority? Priority { get; set; }

        [Required]
        public int UserId { get; set; }
        public User? User { get; set; }

        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
