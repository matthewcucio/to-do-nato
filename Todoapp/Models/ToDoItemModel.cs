namespace Todoapp.Models
{
    public enum Status
    {
        NotStarted,
        Ongoing,
        Completed,
        Backlog
    }

    public enum Priority
    {
        Low,
        Medium,
        High
    }

    public class ToDoItemModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public Status Status { get; set; } = Status.NotStarted;
        public DateTime? Deadline { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; } 
        public Priority Priority { get; set; } = Priority.Medium; 
    }
}