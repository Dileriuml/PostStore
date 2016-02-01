using PostStore.ViewModels;
using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PostStore.Command
{
    public class AsyncCommand : VMBase, ICommand
    {
        #region Events

        public event EventHandler CanExecuteChanged;

        #endregion

        #region Fields

        private bool isExecuting;
        private Func<Task> commandAction;

        #endregion

        #region Cosntructors

        public AsyncCommand(Func<Task> commandAction)
        {
            this.commandAction = commandAction;
        }

        #endregion

        #region Properties

        public bool IsExecuting
        {
            get
            {
                return isExecuting;
            }

            set
            {
                isExecuting = value;
                RaisePropertyChanged();
            }
        }

        #endregion

        #region Public methods

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if (isExecuting)
            {
                return;
            }

            isExecuting = true;
            await ExecuteAsync(parameter);
            isExecuting = false;
        }

        public async virtual Task ExecuteAsync(object parameter)
        {
            if (commandAction != null)
            {
                await commandAction();
            }
        }

        #endregion
    }
}
