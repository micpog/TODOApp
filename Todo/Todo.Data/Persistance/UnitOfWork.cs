using System;
using Todo.Core;
using Todo.Core.Repositories;
using Todo.Data.Persistance.Repositories;

namespace Todo.Data.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TodoDbContext _context;

        public UnitOfWork(TodoDbContext context)
        {
            _context = context;
            Todos = new Repository<Todo.Core.Domain.Todo>(_context);
        }

        public IRepository<Todo.Core.Domain.Todo> Todos { get; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }
    }
}
