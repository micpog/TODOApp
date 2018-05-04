using System;
using System.Collections.Generic;
using Todo.Contracts;
using Todo.Core;

namespace Todo.Services
{
    public class TodoService : ITodoService
    {
        private readonly IUnitOfWork _unitOfWork;

        public TodoService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public TodoService()
        {
        }

        public TodoData GetTodo(Guid id)
        {
            var todo = _unitOfWork.Todos.Get(id);
            if (todo != null)
            {
                return new TodoData
                {
                    Description = todo.Description,
                    EndDate = todo.EndDate,
                    Id = todo.Id,
                    StartDate = todo.StartDate,
                    IsCompleted = todo.IsCompleted
                };
            }

            return null;
        }

        public IEnumerable<TodoData> GetTodos()
        {
            var todosList = new List<TodoData>();
            var todos = _unitOfWork.Todos.GetAll();
            if (todos != null)
            {
                foreach (var todo in todos)
                {
                    todosList.Add(new TodoData
                    {
                        Id = todo.Id,
                        Description = todo.Description,
                        StartDate = todo.StartDate,
                        EndDate = todo.EndDate,
                        IsCompleted = todo.IsCompleted
                    });
                }
            }

            return todosList;
        }

        public IEnumerable<TodoData> GetPendingTodos(bool pendingOnly)
        {
            throw new NotImplementedException();
        }
    }
}
