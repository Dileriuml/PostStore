using System;
using PostStore.Data.Models;
using PostStore.Data.Repositories;
using PostStore.Data.SQL;
using PostStore.Data.Utils;

namespace Test
{
    class Program
    {
        public static void Main(string[] args)
        {
            var db = new RepositoryProvider();

            Console.WriteLine("PostEntries : ");
            db.PostEntries.All().ForEach(Console.WriteLine);

            Console.WriteLine("Types : ");
            db.PostTypes.All().ForEach(Console.WriteLine);

            Console.WriteLine("Packages : ");
            db.PackageRepository.All().ForEach(x => Console.WriteLine(x));
            
            var entry = db.PostEntries.CreateNew();
            var type = db.PostTypes.CreateNew();
            entry.FirstName = "Vasia";
            entry.LastName = "Monster";
            entry.DateOfReport = new DateTime(2014, 12, 1);
            entry.DateOfDischarge = new DateTime(2014, 12, 1);
            entry.DateUplifted = new DateTime(2014, 12, 1);
            entry.Balance = 100;
            entry.ContainerID = "ABDUL";
            entry.VesselName = "Aquilla";
            type.Name = "Shit";

            var package = new Package { Entry = entry, Type = type, Count = 100 };

            db.PackageRepository.AddNew(package);

            Console.WriteLine("Packages : ");
            db.PackageRepository.All().ForEach(x => Console.WriteLine(x));

            Console.ReadKey(true);
        }
    }
}