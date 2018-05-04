using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace Todo.Contracts
{
    [ServiceContract]
    public interface ITodoService
    {
        [OperationContract]
        TodoData GetTodo(Guid id);

        [OperationContract(Name = "GetAllTodos")]
        IEnumerable<TodoData> GetTodos();

        [OperationContract(Name = "GetPendingTodos")]
        IEnumerable<TodoData> GetPendingTodos(bool pendingOnly);
    }
}