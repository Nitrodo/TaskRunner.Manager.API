using AutoMapper;
using Moq;
using System.Linq;
using System.Linq.Expressions;
using TaskRunner.Manager.Application.DTOs.Read;
using TaskRunner.Manager.Application.Services;
using TaskRunner.Manager.Domain.Entities;
using TaskRunner.Manager.Infrastructure.Persitence.Interfaces;
using Xunit;

namespace TaskRunner.Manager.UnitTest.Application
{
    public class TaskDefinitionServiceTests
    {
        private readonly Mock<IRepository<TaskDefinition>> _mockRepository;
        private readonly Mock<IMapper> _mockMapper;
        private readonly TaskDefinitionService _service;

        public TaskDefinitionServiceTests()
        {
            _mockRepository = new Mock<IRepository<TaskDefinition>>();
            _mockMapper = new Mock<IMapper>();
            _service = new TaskDefinitionService(_mockRepository.Object, _mockMapper.Object);
        }

        [Fact]
        public void FindTaskDefinitionByName_NameIsFound_ReturnDTO()
        {
            // Arrange
            var taskDefinitions = GetTaskDefinitions();
            var taskDefinitionReadDTO = GetTaskDefinitionReadDTO();

            _mockRepository.Setup(repo => repo.Find(It.IsAny<Expression<Func<TaskDefinition, bool>>>()))
              .Returns((Expression<Func<TaskDefinition, bool>> predicate) => taskDefinitions.FirstOrDefault(predicate.Compile()));

            _mockMapper.Setup(mapper => mapper.Map<TaskDefinitionReadDTO>(It.IsAny<TaskDefinition>()))
                       .Returns(taskDefinitionReadDTO);

            // Act
            var result = _service.FindTaskDefinitionByName("Test Task");

            // Assert
            Assert.NotNull(result);
            Assert.IsType<TaskDefinitionReadDTO>(result);

            _mockMapper.Verify(mapper => mapper.Map<TaskDefinitionReadDTO>(It.IsAny<TaskDefinition>()), Times.Once);
        }

        [Fact]
        public void FindTaskDefinitionByName_NameIsNotFound_ReturnNull()
        {
            // Arrange
            var taskDefinitions = GetTaskDefinitions();

            _mockRepository.Setup(repo => repo.Find(It.IsAny<Expression<Func<TaskDefinition, bool>>>()))
              .Returns((Expression<Func<TaskDefinition, bool>> predicate) => taskDefinitions.FirstOrDefault(predicate.Compile()));

            // Act
            var result = Assert.Throws<Exception>(() => _service.FindTaskDefinitionByName("Test Task 4"));

            // Assert
            Assert.Equal("Task definition not found", result.Message);

            _mockMapper.Verify(mapper => mapper.Map<TaskDefinitionReadDTO>(It.IsAny<TaskDefinition>()), Times.Never);
        }


        private List<TaskDefinition> GetTaskDefinitions()
        {
            return new List<TaskDefinition>()
                {
                new()
                    {
                    Name = "Test Task",
                    TaskId = 1,
                    Description = "This is a test task",
                    IsActive = true,
                    CreatedDateTime = DateTime.MinValue,
                    ProcessDefinitions = new List<ProcessDefinition>() {
                       new()
                        {
                        ProcessId = 1,
                        Name = "Test Process",
                        Description = "This is a test process",
                        FunctionName = "Function",
                        IsActive = true,
                        IsRetryAllowed = false,
                        Position = 0,
                        TaskId = 1,
                        CreatedDateTime = DateTime.MinValue
                        }
                   }
                },
                new()
                    {
                    Name = "Test Task 2",
                    TaskId = 2,
                    Description = "This is a test task",
                    IsActive = false,
                    CreatedDateTime = DateTime.MinValue,
                    ProcessDefinitions = new List<ProcessDefinition>() {
                       new()
                        {
                        ProcessId = 2,
                        Name = "Test Process 2",
                        Description = "This is a test process",
                        FunctionName = "Function",
                        IsActive = true,
                        IsRetryAllowed = false,
                        Position = 0,
                        TaskId = 2,
                        CreatedDateTime = DateTime.MinValue
                        }
                   }
                }
            };
        }

        private TaskDefinitionReadDTO GetTaskDefinitionReadDTO()
        {
            return new TaskDefinitionReadDTO
            {
                Name = "Test Task",
                Description = "Test Description",
                IsActive = true,
                TaskId = 1,
                CreatedDateTime = DateTime.MinValue,
                ProcessDefinitions = new List<ProcessDefinitionReadDTO>()
                    {
                        new(){
                            Name = "Test Process",
                            Description = "This is a test process",
                            FunctionName = "Function",
                            IsActive = true,
                            IsRetryAllowed = false,
                            Position = 0,
                            TaskId = 1,
                            CreatedDateTime = DateTime.MinValue
                        }
                    }
            };
        }

    }
}
