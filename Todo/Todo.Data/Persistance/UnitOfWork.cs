using System;
using Todo.Core;
using Todo.Core.Repositories;

namespace Todo.Data.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ITodoDbContext _context;

        public UnitOfWork(ITodoDbContext context, ITodoRepository todoRepository)
        {
            _context = context;
            Todos = todoRepository;
        }

        public ITodoRepository Todos { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            throw new NotImplementedException();
        }
    }
}
