namespace TodoConsoleApp.Entity;

public interface ITodoRepository
{
    Todo Save(Todo todo);
}