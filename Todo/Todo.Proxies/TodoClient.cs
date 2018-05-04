using System;
using System.Collections.Generic;
using System.ServiceModel;
using Todo.Contracts;

namespace Todo.Proxies
{
    public class TodoClient : ClientBase<ITodoService>, ITodoService
    {
        public TodoData GetTodo(Guid id)
        {
            return Channel.GetTodo(id);
        }

        public IEnumerable<TodoData> GetTodos()
        {
            return Channel.GetTodos();
        }

        public IEnumerable<TodoData> GetPendingTodos(bool pendingOnly)
        {
            return Channel.GetPendingTodos(pendingOnly);
        }
    }
}
