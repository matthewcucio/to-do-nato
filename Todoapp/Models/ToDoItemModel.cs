namespace Todoapp.Models
{
    public class ToDoItemModel
    {
        public int Id { get; set; } // Unique identifier for the to-do item
        public string Title { get; set; } = string.Empty; // Title or name of the task
        public string? Description { get; set; } // Optional detailed description
        public bool IsCompleted { get; set; } // Status of the task
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow; // Timestamp when the task was created
        public DateTime? DueDate { get; set; } // Optional due date for the task
    }
}
