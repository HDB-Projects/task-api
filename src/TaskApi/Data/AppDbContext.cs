using Microsoft.EntityFrameworkCore;
using TaskApi.Models;

namespace TaskApi.Data;

public class AppDbContext : DbContext
{
    public  AppDbContext(DbContextOptions options) 
        : base(options)
    {
        
    }

    public DbSet<TaskItem> Tasks => Set<TaskItem>();
}
