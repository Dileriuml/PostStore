using System;
using PostStore.Data.Models;

namespace PostStore.ViewModels
{
    public class PostEntryVM : VMBase
    {
        PostEntry entry;

        public PostEntryVM(PostEntry pe)
        {
            this.entry = pe;
        }

        public int Id
        {
            get
            {
                return entry.TSDocId;
            }

            set
            {
                entry.TSDocId = value;
                this.OnPropertyChanged(x => x.Id);
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
                this.OnPropertyChanged(x => x.ContainerID);
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
                this.OnPropertyChanged(x => x.FirstName);
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
                this.OnPropertyChanged(x => x.LastName);
            }
        }

        public string VesselName
        {
            get
            {
                return entry.VesselName;
            }

            set
            {
                entry.VesselName = value;
                this.OnPropertyChanged(x => x.VesselName);
            }
        }

        public int Balance
        {
            get
            {
                return entry.Balance;
            }

            set
            {
                entry.Balance = value;
                this.OnPropertyChanged(x => x.Balance);
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
                this.OnPropertyChanged(x => x.UpliftedDate);
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
                this.OnPropertyChanged(x => x.DateOfReport);
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
                this.OnPropertyChanged(x => x.DateOfDischarge);
            }
        }
    }
}
