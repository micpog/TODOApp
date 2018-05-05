using System.Collections.Generic;

namespace Todo.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<global::Todo.Data.Persistance.TodoDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Persistance.TodoDbContext context)
        {
            #region Add Todos

            var todos = new List<Core.Domain.Todo>
            {
                new Core.Domain.Todo
                {
                    Id = Guid.NewGuid(),
                    Description = "Clean house",
                    StartDate = new DateTime(2018, 5, 15),
                    EndDate = new DateTime(2018, 5, 16),
                    IsCompleted = false
                }
            };
            #endregion

            foreach (var todo in todos)
            {
                context.Todos.AddOrUpdate(t => t.Id, todo);
            }

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
