using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using Todo.Core;

namespace Todo.Client.Todos
{
    public class TodosViewModel
    {
        public IUnitOfWork UnitOfWork { get; set; }

        public TodosViewModel()
        {
            if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                return;
            }

            Todos = new ObservableCollection<Data.Core.Domain.Todo>(UnitOfWork.Todos.GetAll());
        }

        public ObservableCollection<Data.Core.Domain.Todo> Todos { get; set; }
    }
}
