using TodoConsoleApp.Dto;
using TodoConsoleApp.Entity;

namespace TodoConsoleApp.Service;

public interface ITodoService
{
    public Todo Create(TodoRequest todoRequest);
    TodoRequest ReadTodoRequest();
}