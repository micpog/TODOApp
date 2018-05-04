using System;
using Todo.Core.Repositories;

namespace Todo.Core
{
    public interface IUnitOfWork : IDisposable
    {
        ITodoRepository Todos { get; }
        int Complete();
    }
}