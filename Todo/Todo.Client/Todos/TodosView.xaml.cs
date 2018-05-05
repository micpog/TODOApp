using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Windows.Controls;
using Todo.Core;
using Todo.Data.Persistance;
using Todo = Todo.Core.Domain.Todo;

namespace Todo.Client.Todos
{
    /// <summary>
    /// Interaction logic for TodosView.xaml
    /// </summary>
    public partial class TodosView : UserControl
    {
        private TodoDbContext _context = new TodoDbContext();
        private List<Core.Domain.Todo> Todos = new List<Core.Domain.Todo>();
        

        public TodosView()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            {
                System.Windows.Data.CollectionViewSource myCollectionViewSource =
                    (System.Windows.Data.CollectionViewSource) this.Resources["todoViewSource"];
                _context.Todos
                    .Where(t => !t.IsCompleted)
                    .OrderBy(t => t.StartDate)
                    .ThenBy(t => t.EndDate)
                    .Load();
                myCollectionViewSource.Source = _context.Todos.Local;
            }
        }

        private void Add_New_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var newTodo = new Core.Domain.Todo
            {
                Id = Guid.NewGuid()
            };

            _context.Todos.Local.Add(newTodo);
            Todos.Add(newTodo);
        }

        private void Save_Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _context.Todos.AddRange(Todos);
            Todos = null;
            _context.SaveChanges();
        }
    }
}