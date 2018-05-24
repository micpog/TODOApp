using System;
using System.Collections.Generic;
using System.ServiceModel;
using Services;

namespace Todo.Proxies
{
    public class TodoClient : ClientBase<ITodoService>, ITodoService
    {
        public Core.Domain.Todo GetTodo(Guid id)
        {
            return Channel.GetTodo(id);
        }

        public IEnumerable<Core.Domain.Todo> GetTodos()
        {
            return Channel.GetTodos();
        }

        public IEnumerable<Core.Domain.Todo> GetPendingTodos(bool pendingOnly)
        {
            return Channel.GetPendingTodos(pendingOnly);
        }
    }
}
