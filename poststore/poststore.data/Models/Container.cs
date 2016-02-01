using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostStore.Data.Models
{
    [Table("containers")]
    public class Container
    {
        [Key]
        public string ContainerId { get; set; }

        [ForeignKey(nameof(Vessel))]
        public int VesselId { get; set; }

        public Vessel Vessel { get; set; }

        public virtual ObservableCollection<PostEntry> PostEntries { get; set; }
    }
}
