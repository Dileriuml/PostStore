using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostStore.Data.Models
{
    [Table("vessels")]
    public class Vessel
    {
        [Key]
        public int Id { get; set; }
        
        public string Name { get; set; }

        public ObservableCollection<Container> Containers { get; set; }
    }
}
