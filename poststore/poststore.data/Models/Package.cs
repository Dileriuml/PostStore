using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PostStore.Data.Models
{
    [Table("packages")]
    public class Package
    {
        [Key]
        [Column(Order = 0)]
        [ForeignKey("Entry")]
        public int DocId { get; set; }

        [Key]
        [Column(Order = 1)]
        [ForeignKey("Type")]
        public int ItemTypeId { get; set; }

        public int Count { get; set; }

        public PostEntry Entry { get; set; }

        public PostType Type { get; set; }

        public override string ToString()
        {
            return $"{Entry.FirstName} of type {Type.Name}";
        }
    }
}
