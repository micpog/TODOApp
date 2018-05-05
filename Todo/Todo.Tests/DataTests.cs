using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using Todo.Data.Persistance.Repositories;
using Todo = Todo.Core.Domain.Todo;

namespace Todo.Tests
{
    [TestFixture]
    public class DataTests
    {
        [Test]
        public void GetAll_Should_RetrieveAllTodos()
        {
            // Arrange
            var repository = Substitute.For<Repository<Core.Domain.Todo>>();

            var todos = new List<Core.Domain.Todo>
            {
                new Core.Domain.Todo
                {
                    Id = Guid.NewGuid(),
                    Description = "Dinner",
                    StartDate = new DateTime(2018, 5, 12),
                    EndDate = new DateTime(2018, 5, 13),
                    IsCompleted = false
                }
            };

            repository.GetAll().Returns(todos);

            // Act
            

            // Assert

        }
    }
}
