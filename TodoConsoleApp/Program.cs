using Microsoft.Extensions.DependencyInjection;
using TodoConsoleApp.Dto;
using TodoConsoleApp.Service;
using Microsoft.EntityFrameworkCore;
using TodoConsoleApp.Entity;

var connectionString = "Server=localhost,1433;Database=TodoDb;User Id=sa;Password=testPassword!1;TrustServerCertificate=True;";

// Similar to a Spring ApplicationContext.
// You register services with ServiceCollection, and resolve them using ServiceProvider.
var serviceCollection = new ServiceCollection();

// add singleton
serviceCollection.AddSingleton<ITodoService, TodoService>();
serviceCollection.AddSingleton<IConsoleService, ConsoleService>();
// create per request
serviceCollection.AddTransient<App>();
serviceCollection.AddDbContext<TodoDbContext>(options =>
    options.UseSqlServer(connectionString));

serviceCollection.AddScoped<ITodoRepository, TodoRepository>();

// build continer
var serviceProvider = serviceCollection.BuildServiceProvider();

// get App bean
var app = serviceProvider.GetRequiredService<App>();
app.Run();

public class App
{
    private readonly ITodoService _todoService;
    private readonly IConsoleService _consoleService;

    public App(ITodoService todoService, IConsoleService consoleService)
    {
        _todoService = todoService;
        _consoleService = consoleService;
    }

    public void Run()
    {
        //_consoleService.PrintHelp();
        _todoService.Create(null);
        // Simulating user input
        while (!_consoleService.IsExistRequested())
        {
            _consoleService.PrintTodoRequest();
            //TodoRequest todoRequest = _consoleService.ReadTodoRequest(); // This should be implemented in IConsoleService
          //  _todoService.Create(todoRequest);
            //_consoleService.PrintTodoRequestCreationInfo(todoRequest);
        }
    }
}