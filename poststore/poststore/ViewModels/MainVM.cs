using PostStore.Commands;
using PostStore.Data.Models;
using PostStore.Data.Repositories;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;

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
        }

        #endregion

        #region Properties

        public ICommand CreateNewEntryCommand
        {
            get;
            private set;
        }

        public ObservableCollection<PostEntryVM> Items { get; private set; }

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
                VesselName = "VESSEL",
                TSDocId = 1
            };
            provider.PostEntries.AddNew(postEntry);
            Items.Add(new PostEntryVM(postEntry));
        }

        #endregion
    }
}
