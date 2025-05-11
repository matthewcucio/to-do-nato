namespace Todoapp.Models
{
    public class ToDoItemModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsCompleted { get; set; }
        public DateTime? Deadline { get; set; }
        public string? Description { get; set; }
    }
}

