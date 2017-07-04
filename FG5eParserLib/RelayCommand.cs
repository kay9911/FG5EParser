using System;
using System.Windows.Input;

namespace FG5eParserLib
{
    public class RelayCommand : ICommand
    {
        // Properties
        readonly Action<object> _execute;
        readonly Predicate<object> _canExecute;

        // Functionality constructor
        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            if (execute == null)
                throw new NullReferenceException("execute");

            _execute = execute;
            _canExecute = canExecute;
        }

        // Re routed constructor
        public RelayCommand(Action<object> execute) : this(execute,null)
        {

        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }

    public class GenericRelayCommand<T> : ICommand
    {
        private readonly Action<T> _execute;
        public Predicate<T> CanExecuteFunc { get; private set; }

        public GenericRelayCommand(Action<T> execute) : this(execute, p => true)
        { }

        public GenericRelayCommand(Action<T> execute, Predicate<T> canExecuteFunc)
        {
            _execute = execute;
            CanExecuteFunc = canExecuteFunc;
        }

        public bool CanExecute(object parameter)
        {
            var canExecute = CanExecuteFunc((T)parameter);
            return canExecute;
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }

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
    }
}
