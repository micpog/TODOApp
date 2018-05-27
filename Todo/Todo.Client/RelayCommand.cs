using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Todo.Client
{
    public class RelayCommand : ICommand
    {
        private Action _TargetExecuteMethod;
        private Func<bool> _CanExecuteMethod;

        public RelayCommand(Action targetExecuteMethod, Func<bool> canExecuteMethod)
        {
            _TargetExecuteMethod = targetExecuteMethod;
            _CanExecuteMethod = canExecuteMethod;
        }

        public RelayCommand(Action targetExecuteMethod)
        {
            _TargetExecuteMethod = targetExecuteMethod;
        }

        public bool CanExecute(object parameter)
        {
            if (_CanExecuteMethod != null)
            {
                return _CanExecuteMethod();
            }

            if (_TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            _TargetExecuteMethod?.Invoke();
        }

        public event EventHandler CanExecuteChanged;
    }
}
