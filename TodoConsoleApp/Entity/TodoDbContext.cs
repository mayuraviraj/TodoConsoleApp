using Microsoft.EntityFrameworkCore;

namespace TodoConsoleApp.Entity;

public class TodoDbContext : DbContext
{
    public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options) { }

    public DbSet<Todo> Todos { get; set; }
}