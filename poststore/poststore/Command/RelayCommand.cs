using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using PostStore.Data.Utils;

namespace PostStore.Commands
{
    public class RelayCommand<T> : ICommand
    {
        #region Private fields

        private Action<T> action;
        private Func<T, bool> canExecuteEval;

        #endregion

        #region Constructors

        public RelayCommand(Action<T> action)
        {
            this.action = action;
        }

        public RelayCommand(Action<T> action, Func<T, bool> canExecuteEval)
        {
            this.action = action;
            this.canExecuteEval = canExecuteEval;
        }

        #endregion

        #region Public methods

        public void Execute(object parameter)
        {
            action.With(act => act((T)parameter));
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteEval == null || canExecuteEval((T)parameter);
        }

        public void OnCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            handler.With(hEvent => hEvent(this, EventArgs.Empty));
        }

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion
    }

    public class CollectionRelayCommand<T> : ICommand
    {
        #region Private fields

        private Action<IEnumerable<T>> action;
        private Func<IEnumerable<T>, bool> canExecuteEval;

        #endregion

        #region Contructors

        public CollectionRelayCommand(Action<IEnumerable<T>> action)
        {
            this.action = action;
        }

        public CollectionRelayCommand(Action<IEnumerable<T>> action, Func<IEnumerable<T>, bool> canExecuteEval)
        {
            this.action = action;
            this.canExecuteEval = canExecuteEval;
        }

        #endregion

        #region Public methods

        public void Execute(object parameter)
        {
            action.With(act => act(parameter.WithType<IEnumerable<object>, IEnumerable<T>>(x => x.Cast<T>())));
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteEval == null || canExecuteEval(parameter.WithType<IEnumerable<object>, IEnumerable<T>>(x => x.Cast<T>()));
        }

        public void OnCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            handler.With(hEvent => hEvent(this, EventArgs.Empty));
        }

        #endregion

        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion
    }
}
