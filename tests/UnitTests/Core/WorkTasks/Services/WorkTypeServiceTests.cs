using FluentAssertions;
using Moq;
using Taskhub.Core.Common.Abstractions;
using Taskhub.Core.WorkTasks;
using Taskhub.Core.WorkTasks.Abstractions;
using Taskhub.Core.WorkTasks.Services;
using Taskhub.Core.WorkTasks.Specifications;

namespace Taskhub.UnitTests.Core.WorkTasks.Services;

public class WorkTypeServiceTests
{
    private WorkTaskService _sut;
    private Mock<IWorkTaskRepository> _workTypeRepositoryMock;
    private Mock<IDateTimeProvider> _dateTimeProviderMock;

    public WorkTypeServiceTests()
    {
        _workTypeRepositoryMock = new Mock<IWorkTaskRepository>();
        _workTypeRepositoryMock.Setup(x => x.ListAsync(It.IsAny<WorkTaskByDaySpecification>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync([
                new()
                {
                    Id = Guid.NewGuid(),
                    Title = "Add some very basic unit tests for now",
                    Day = DateTime.Parse("2024-12-08"),
                },
            ]);

        _dateTimeProviderMock = new Mock<IDateTimeProvider>();
        _dateTimeProviderMock.Setup(x => x.UtcNow)
            .Returns(DateTime.Parse("2024-12-08"));

        _sut = new WorkTaskService(_workTypeRepositoryMock.Object, _dateTimeProviderMock.Object);
    }

    [Fact]
    public async Task GetWorkTasksForToday_TasksExists_ReturnsTasks()
    {
        // Act
        var workTasks = await _sut.GetWorkTasksForToday();

        // Assert
        workTasks.Should().HaveCount(1);
    }

    [Fact]
    public async Task GetWorkTasksByDate_TasksExists_ReturnsTasks()
    {
        // Act
        var workTasks = await _sut.GetWorkTasksForDate(DateTime.Parse("2024-12-08"));

        // Assert
        workTasks.Should().HaveCount(1);
    }

    [Fact]
    public async Task GetWorkTask_TaskExists_ReturnsTask()
    {
        // Arrange
        var id = Guid.NewGuid();

        _workTypeRepositoryMock.Setup(x => x.GetByIdAsync(It.IsAny<Guid>(), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new WorkTask
            {
                Id = id,
                Title = "Add some very basic unit tests for now",
                Day = DateTime.Parse("2024-12-08"),
            });

        // Act
        var workTask = await _sut.GetWorkTask(id);

        // Assert
        workTask.Should().NotBeNull();
    }
}
