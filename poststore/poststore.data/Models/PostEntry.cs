
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

        [ForeignKey(nameof(Container))]
        public string ContainerID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        
        public double Balance { get; set; }

        public DateTime DateUplifted { get; set; }

        public DateTime DateOfReport { get; set; }

        public DateTime DateOfDischarge { get; set; }

        public virtual ObservableCollection<Package> Items { get; set; }

        public Container Container { get; set; }
    }
}
