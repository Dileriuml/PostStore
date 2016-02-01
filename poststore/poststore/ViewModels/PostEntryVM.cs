using System;
using PostStore.Data.Models;
using System.Collections.ObjectModel;

namespace PostStore.ViewModels
{
    public class PostEntryVM : VMBase
    {
        #region Fields

        private PostEntry entry;

        #endregion

        #region Constructors

        public PostEntryVM(PostEntry pe)
        {
            this.entry = pe;
        }

        #endregion

        #region Properties

        public int DocumentID
        {
            get
            {
                return entry.TSDocId;
            }

            set
            {
                entry.TSDocId = value;
                RaisePropertyChanged();
            }
        }

        public string ContainerID
        {
            get
            {
                return entry.ContainerID;
            }

            set
            {
                entry.ContainerID = value;
                RaisePropertyChanged();
            }
        }

        public string FirstName
        {
            get
            {
                return entry.FirstName;
            }

            set
            {
                entry.FirstName = value;
                RaisePropertyChanged();
            }
        }

        public string LastName
        {
            get
            {
                return entry.LastName;
            }

            set
            {
                entry.LastName = value;
                RaisePropertyChanged();
            }
        }

        public double Balance
        {
            get
            {
                return entry.Balance;
            }

            set
            {
                entry.Balance = value;
                RaisePropertyChanged();
            }
        }

        public DateTime UpliftedDate
        {
            get
            {
                return entry.DateUplifted;
            }

            set
            {
                entry.DateUplifted = value;
                RaisePropertyChanged();
            }
        }

        public DateTime DateOfReport
        {
            get
            {
                return entry.DateOfReport;
            }

            set
            {
                entry.DateOfReport = value;
                RaisePropertyChanged();
            }
        }

        public DateTime DateOfDischarge
        {
            get
            {
                return entry.DateOfDischarge;
            }

            set
            {
                entry.DateOfDischarge = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<Package> Cargo
        {
            get
            {
                return entry.Items;
            }
        }

        #endregion
    }
}
