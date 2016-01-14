using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostStore.Data.Models
{
    [Table("entries")]
    public class PostEntry
    {
        public PostEntry()
        {
            Items = new ObservableCollection<Package>();
        }

        [Key]
        public int TSDocId { get; set; }

        public string ContainerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string VesselName { get; set; }

        public int Balance { get; set; }

        public DateTime DateUplifted { get; set; }

        public DateTime DateOfReport { get; set; }

        public DateTime DateOfDischarge { get; set; }

        public virtual ObservableCollection<Package> Items { get; set; }

        public override string ToString()
        {
            return string.Format("[PostEntry TSDocId={0}, ContainerID={1}, FirstName={2}, LastName={3}, VesselName={4}, Balance={5}, Uplifted={6}, DateOfReport={7}, DateOfDischarge={8}]", TSDocId, ContainerID, FirstName, LastName, VesselName, Balance, DateUplifted, DateOfReport, DateOfDischarge);
        }

    }
}
