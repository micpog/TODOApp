using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
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
            }
        }

        public ICommand SaveCommand { get; private set; }

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
            TodoServiceClient service = new TodoServiceClient();
            service.SaveAllChanges();
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
