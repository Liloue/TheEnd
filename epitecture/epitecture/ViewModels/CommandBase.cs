using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace epitecture.ViewModels
{
    class CommandBase : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action<object> _execute;

        public CommandBase(Action<object> toExecute)
        {
            _execute = toExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _execute(parameter);
            }
        }
    }
}

