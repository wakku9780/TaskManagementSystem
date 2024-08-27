using TaskManagementSystem.Models;
using TaskManagementSystem.ViewModels;
using Microsoft.EntityFrameworkCore;
using TaskManagementSystem.Data;

namespace TaskManagementSystem.Services
{
    public class TaskService
    {
        private readonly ApplicationDbContext _context;

        public TaskService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskItem> GetAllTasks()
        {
            return _context.Tasks.Include(t => t.User).ToList();
        }

        public async Task<TaskItem> GetTaskByIdAsync(int id)
        {
            return await _context.Tasks.Include(t => t.User).FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task CreateTaskAsync(TaskViewModel model)
        {
            var task = new TaskItem
            {
                Title = model.Title,
                Description = model.Description,
                Status = model.Status,
                UserId = model.UserId,
                CreatedAt = DateTime.Now,
                DueDate = model.DueDate
            };

            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTaskAsync(TaskViewModel model)
        {
            var task = await _context.Tasks.FindAsync(model.Id);
            if (task != null)
            {
                task.Title = model.Title;
                task.Description = model.Description;
                task.Status = model.Status;
                task.UserId = model.UserId;
                task.DueDate = model.DueDate;

                await _context.SaveChangesAsync();
            }
        }

        public async Task DeleteTaskAsync(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task != null)
            {
                _context.Tasks.Remove(task);
                await _context.SaveChangesAsync();
            }
        }
    }
}
