using System.Windows.Controls;
using Todo.Core;

namespace Todo.Client.Todos
{
    /// <summary>
    /// Interaction logic for TodosView.xaml
    /// </summary>
    public partial class TodosView : UserControl
    {
        public TodosView()
        {
            this.DataContext = new TodosViewModel();
            InitializeComponent();
        }
    }
}
