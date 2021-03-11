using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Univer.Commands
{
    class RelayCommand : ICommand
    {
        private Action<object> _Execute;
        private Func<object, bool> _CanExecute;

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public RelayCommand(Action<object> Execute, Func<object, bool> CanExecute)
        {
            _Execute = Execute;
            _CanExecute = CanExecute;
        }

        public void Execute(object parameter) => _Execute(parameter);

        public bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;
    }
}
