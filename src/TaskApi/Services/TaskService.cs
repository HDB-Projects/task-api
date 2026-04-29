using Microsoft.EntityFrameworkCore;
using TaskApi.Data;
using TaskApi.Models;

namespace TaskApi.Services;

public class TaskService
{
    private readonly AppDbContext _context;

    public TaskService(AppDbContext appDbContext)
    {
        _context = appDbContext;
    }

    public async Task<List<TaskItem>> GetAllAsync()
    {
        return await _context.Tasks.ToListAsync();
    }

    public async Task<TaskItem?> GetByIdAsync(Guid id)
    {
        return await _context.Tasks.FindAsync(id);
    }

    public async Task<TaskItem> CreateAsync(TaskItem taskItem)
    {
        _context.Tasks.Add(taskItem);
        await _context.SaveChangesAsync();
        return taskItem;
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        TaskItem? task = await _context.Tasks.FindAsync(id);
        if (task == null) return false;

        _context.Tasks.Remove(task);
        await _context.SaveChangesAsync();
        return true;
    }
}
