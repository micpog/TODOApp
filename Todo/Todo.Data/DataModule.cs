using Autofac;
using Todo.Core;
using Todo.Core.Repositories;
using Todo.Data.Persistance;
using Todo.Data.Persistance.Repositories;

namespace Todo.Data
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerRequest();
        }
    }
}
