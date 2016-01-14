using System.Windows.Input;
using PostStore.Data.Repositories;

namespace PostStore.ViewModels
{
    public class MainVM : VMBase
    {
        private RepositoryProvider provider;

        public MainVM()
        {
            provider = new RepositoryProvider();
        }

        ICommand CreateNewEntryCommand
        {
            get
            {
                return null;
            }
        }
    }
}
