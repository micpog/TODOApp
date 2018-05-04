using System;
using System.ServiceModel;
using Autofac;
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

            containerBuilder.Build();

            var host = new ServiceHost(typeof(TodoService));
            host.Open();
            Console.WriteLine("Click Enter to stop the service.");
            Console.ReadLine();
            host.Close();
        }
    }
}
