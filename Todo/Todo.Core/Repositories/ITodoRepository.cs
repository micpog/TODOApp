using Todo.Data.Core.Repositories;

namespace Todo.Core.Repositories
{
    public interface ITodoRepository : IRepository<Data.Core.Domain.Todo>
    {
    }
}