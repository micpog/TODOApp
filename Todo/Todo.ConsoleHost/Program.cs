using System;
using System.ServiceModel;
using Autofac;
using Autofac.Integration.Wcf;
using Services;
using Todo.Data;

namespace Todo.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<ServiceModule>();
            containerBuilder.RegisterModule<DataModule>();

            using (var container = containerBuilder.Build())
            {
                var host = new ServiceHost(typeof(TodosService));
                host.AddDependencyInjectionBehavior<ITodoService>(container);
                host.Open();
                Console.WriteLine("Click Enter to stop the service.");
                Console.ReadLine();
                host.Close();
            }
        }
    }
}
