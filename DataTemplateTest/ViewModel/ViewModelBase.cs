using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataTemplateTest.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void RaisePropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class Command : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action action;

        public Command(Action action)
        {
            this.action = action;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            action?.Invoke();
        }
    }

    public class Command<T> : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private readonly Action<T> action;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public Command(Action<T> action)
        {
            this.action = action;
        }
        public void Execute(object parameter)
        {
            action?.Invoke((T)parameter);
        }
    }
}
