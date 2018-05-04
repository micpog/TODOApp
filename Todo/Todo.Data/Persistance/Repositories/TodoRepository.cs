using System;
using System.Data.Entity;
using Todo.Core.Repositories;

namespace Todo.Data.Persistance.Repositories
{
    public class TodoRepository : Repository<Core.Domain.Todo>, ITodoRepository
    {
        public TodoRepository(ITodoDbContext context) : base(context)
        {
        }
    }
}
