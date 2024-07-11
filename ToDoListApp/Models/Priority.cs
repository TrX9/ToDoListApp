namespace ToDoListApp.Models
{
    public class Priority
    {
        public int Level { get; set; }
        public ICollection<ToDoItem> ToDoItems { get; set; }
    }
}
