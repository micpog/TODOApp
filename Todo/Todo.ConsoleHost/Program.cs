using System;
using System.ServiceModel;
using Autofac;
using Autofac.Integration.Wcf;
using Todo.Contracts;
using Todo.Data;
using Todo.Services;

namespace Todo.ConsoleHost
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule<ServicesModule>();
            containerBuilder.RegisterModule<DataModule>();

            using (var container = containerBuilder.Build())
            {
                var host = new ServiceHost(typeof(TodoService));
                host.AddDependencyInjectionBehavior<ITodoService>(container);
                host.Open();
                Console.WriteLine("Click Enter to stop the service.");
                Console.ReadLine();
                host.Close();
            }


        }
    }
}
