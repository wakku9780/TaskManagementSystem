using TaskManagementSystem.Models;

namespace TaskManagementSystem.ViewModels
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        // Fully qualified name to avoid ambiguity
        public TaskManagementSystem.Models.TaskStatus Status { get; set; }
        public DateTime DueDate { get; set; } // Add this property

        public string UserId { get; set; }

        public User User { get; set; }
    }
}
