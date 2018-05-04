using System.Data.Entity;

namespace Todo.Data.Persistance
{
    public class TodoDbContext : DbContext, ITodoDbContext
    {
        public TodoDbContext() 
            : base("name=TodoDb")
        {
        }

        public DbSet<Core.Domain.Todo> Todos { get; set; }
        public void SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }

    public interface ITodoDbContext
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;
        void Dispose();
        void SaveChanges();
    }
}
