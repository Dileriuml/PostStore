using PostStore.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace PostStore.Converters
{
    public class CargoConverter : GenericConverter<IEnumerable<Package>, string>
    {
        public CargoConverter() : base(cargoCollection => 
            cargoCollection.Any() ? string.Join(", ", cargoCollection.Select(package => package.ToString()))
            : "No cargo")
        {

        }
    }
}
