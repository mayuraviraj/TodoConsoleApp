using TodoConsoleApp.Dto;
using TodoConsoleApp.Entity;

namespace TodoConsoleApp.Service;

public class TodoService(ITodoRepository _repository) : ITodoService
{
    public Todo Create(TodoRequest todoRequest)
    {
        _repository.Save(new Todo
        {
            Description = "TESt",
            Title = "Title",

        });
        return null;
    }

    public TodoRequest ReadTodoRequest()
    {
        throw new NotImplementedException();
    }
}