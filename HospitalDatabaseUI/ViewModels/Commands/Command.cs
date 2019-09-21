using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HospitalDatabaseUI.ViewModels.Commands
{
    public class Command : ICommand
    {
        Action executeMethod;
        Predicate<object> canexecuteMethod;

        public Command(Action executeMethod, Predicate<object> canexecuteMethod)
        {
            this.executeMethod = executeMethod;
            this.canexecuteMethod = canexecuteMethod;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return canexecuteMethod == null ? true : canexecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            executeMethod();
        }
    }
}
