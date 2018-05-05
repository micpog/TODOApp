using System.Data.Entity;

namespace Todo.Data.Persistance
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext() 
            : base("name=Todo")
        {
            Configuration.LazyLoadingEnabled = true;
        }

        public DbSet<Todo.Core.Domain.Todo> Todos { get; set; }
    }
}
