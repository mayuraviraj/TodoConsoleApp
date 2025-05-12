namespace TodoConsoleApp.Entity;

public class TodoRepository : ITodoRepository
{
    private readonly TodoDbContext _context;

    public TodoRepository(TodoDbContext context)
    {
        _context = context;
    }
    
    public Todo Save(Todo todo)
    {
        _context.Todos.Add(todo);
        _context.SaveChanges();
        Console.WriteLine("Saved");
        IEnumerable<Todo> all = _context.Todos.ToList();
        foreach (var each in all)
        {
            Console.WriteLine(each);
        }
        return todo;
    }
}