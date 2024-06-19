namespace TODO.Data.Models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedOn { get; set;}
        public required string CreatedEmail { get; set; }
        public string? ModifiedEmail { get; set; }
    }
}
