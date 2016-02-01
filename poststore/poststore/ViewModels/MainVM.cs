using PostStore.Command;
using PostStore.Commands;
using PostStore.Data.Models;
using PostStore.Data.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace PostStore.ViewModels
{
    public class MainVM : VMBase
    {
        #region Fields

        private RepositoryProvider provider;

        #endregion

        #region Constructor

        public MainVM()
        {
            provider = new RepositoryProvider();
            CreateNewEntryCommand = new DelegateCommand(AddPostEntry);
            Items = new ObservableCollection<PostEntryVM>(provider.PostEntries.All().Select(x => new PostEntryVM(x)));
            SaveCommand = new AsyncCommand(DoSaveCommand);
            EditCargoCommand = new DelegateCommand(DoEditCargo);
        }

        #endregion

        #region Properties

        public DelegateCommand CreateNewEntryCommand
        {
            get;
            private set;
        }

        public AsyncCommand SaveCommand
        {
            get;
            private set;
        }

        public DelegateCommand EditCargoCommand
        {
            get;
            private set;
        }

        public ObservableCollection<PostEntryVM> Items
        {
            get;
            private set;
        }

        #endregion

        #region Public methods

        public void AddPostEntry()
        {
            var postEntry = new PostEntry
            {
                FirstName = "Maxym",
                LastName = "Goliak",
                ContainerID = "FUCK'N CONTAINER",
                DateOfDischarge = DateTime.Now,
                DateOfReport = DateTime.Now,
                DateUplifted = DateTime.Now,
                Balance = 100,
                TSDocId = 1
            };
            provider.PostEntries.AddNew(postEntry);
            Items.Add(new PostEntryVM(postEntry));
        }

        public void DoEditCargo()
        {
            
        }

        public async Task DoSaveCommand()
        {
            await provider.SaveAllAsync();
        }

        #endregion
    }
}
