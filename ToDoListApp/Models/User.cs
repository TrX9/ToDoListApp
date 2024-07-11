using System.ComponentModel.DataAnnotations;

namespace ToDoListApp.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required]
        [StringLength(100)] 
        public string? Name { get; set; }
        public ICollection<ToDoItem>? ToDoItems { get; set; }
    }
}
