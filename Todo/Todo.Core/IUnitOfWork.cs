using System;
using Todo.Core.Repositories;

namespace Todo.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Domain.Todo> Todos { get; }
        int Complete();
    }
}