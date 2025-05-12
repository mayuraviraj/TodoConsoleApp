using JetBrains.Annotations;
using Moq;
using TodoConsoleApp.Dto;
using TodoConsoleApp.Entity;
using TodoConsoleApp.Service;

namespace TodoConsoleApp.Tests.Service;

[TestSubject(typeof(ITodoService))]
public class TodoServiceTest
{

    [Fact]
    public void CreateTodo_Should_Saved_To_DB_And_Return_Id()
    {
        // Arrange
        var todoRequest = new TodoRequest { Title = "Test", Description = "Write Tests" };
        var savedTodo = new Todo
        {
            Id = Guid.NewGuid(),
            Title = todoRequest.Title,
            Description = todoRequest.Description
        };
        var repoMock = new Mock<ITodoRepository>();
        repoMock.Setup(r => r.Save(It.IsAny<Todo>())).Returns(savedTodo);
        var service = new TodoService(repoMock.Object);
        
        // Act
        var result = service.Create(todoRequest);
        
        // Assert
        Assert.Equal(savedTodo.Id, result.Id);
        Assert.Equal("Test", result.Title);
        Assert.Equal("Write Tests", result.Description);
        repoMock.Verify(r => r.Save(It.IsAny<Todo>()), Times.Once);
    }
}