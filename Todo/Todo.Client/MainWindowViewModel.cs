using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows;
using System.Windows.Input;
using Todo.Client.Annotations;
using Todo.Client.TodosService;

namespace Todo.Client
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Core.Domain.Todo> _todos;

        public MainWindowViewModel()
        {
            if (!DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                LoadTodos();
                SaveCommand = new RelayCommand(OnSave);
            }
        }

        public RelayCommand SaveCommand { get; private set; }

        public ObservableCollection<Core.Domain.Todo> Todos
        {
            get => _todos;
            set
            {
                if (value != null)
                {
                    _todos = value;
                    OnPropertyChanged(nameof(Todos));
                }
            }
        }
        
        private void LoadTodos()
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-us");
            TodoServiceClient service = new TodoServiceClient();
            service.Open();
            Todos = new ObservableCollection<Core.Domain.Todo>(service.GetAllTodos());
            service.Close();
        }

        private void OnSave()
        {
            foreach (var t in Todos)
            {
                if (t.Id == Guid.Empty)
                {
                    t.Id = Guid.NewGuid();
                }
            }
            TodoServiceClient service = new TodoServiceClient();
            service.SaveAllChanges(Todos.ToArray());
            service.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
