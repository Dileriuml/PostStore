using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostStore.Data.Models
{
    [Table("types")]
    public class PostType
    {
        public PostType()
        {
            AsociatedPackages = new ObservableCollection<Package>();
        }

        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ObservableCollection<Package> AsociatedPackages { get; set; }

        public override string ToString()
        {
            return string.Format("[PostType Id={0}, Name={1}]", Id, Name);
        }
    }
}
