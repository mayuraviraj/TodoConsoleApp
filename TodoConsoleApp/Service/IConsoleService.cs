using TodoConsoleApp.Dto;

namespace TodoConsoleApp.Service;

public interface IConsoleService
{
    void PrintHelp();
    bool IsExistRequested();
    void PrintTodoRequest();
    void PrintTodoRequestCreationInfo(TodoRequest todoRequest);
}