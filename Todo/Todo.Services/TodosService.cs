using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using Todo.Data.Persistance.Repositories;

namespace Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class TodosService : ITodoService, IDisposable
    {
        private Repository<Todo.Core.Domain.Todo> _repository;

        public TodosService()
        {
            _repository = new Repository<Todo.Core.Domain.Todo>();
        }

        public Todo.Core.Domain.Todo GetTodo(Guid id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<Todo.Core.Domain.Todo> GetTodos()
        {
            return _repository.GetAll().ToList();
        }

        public IEnumerable<Todo.Core.Domain.Todo> GetPendingTodos(bool pendingOnly)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
