using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Services
{
    [ServiceContract]
    public interface ITodoService
    {
        [OperationContract]
        Todo.Core.Domain.Todo GetTodo(Guid id);

        [OperationContract(Name = "GetAllTodos")]
        IEnumerable<Todo.Core.Domain.Todo> GetTodos();

        [OperationContract(Name = "GetPendingTodos")]
        IEnumerable<Todo.Core.Domain.Todo> GetPendingTodos(bool pendingOnly);
    }
}