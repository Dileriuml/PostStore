using System;
using System.Windows.Input;
using PostStore.Data.Utils;

namespace PostStore.Commands
{
    public class DelegateCommand : ICommand
    {
        #region Private fields

        private Action action;

        #endregion

        #region Constructors

        public DelegateCommand(Action action)
        {
            this.action = action;
        }

        #endregion

        #region Public methods

        public void Execute(object parameter)
        {
            action.With(act => act());
        }

        public bool CanExecute(object parameter)
        {
            return true;
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
