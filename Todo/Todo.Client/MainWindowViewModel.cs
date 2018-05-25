using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Todo.Client.Connected_Services.TodosService;

namespace Todo.Client
{
    public class MainWindowViewModel 
    {
        public ObservableCollection<Core.Domain.Todo> Todos { get; set; }

        public MainWindowViewModel()
        {
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                LoadTodos();
            }
        }

        private void LoadTodos()
        {
            TodoServiceClient service = new TodoServiceClient("BasicHttpBinding_ITodoService");
            service.Open();
            Todos = new ObservableCollection<Core.Domain.Todo>(service.GetAllTodos());
            service.Close();
        }
    }
}
