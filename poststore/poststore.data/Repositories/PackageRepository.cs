using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PostStore.Data.Models;
using PostStore.Data.Repositories.Interfaces;
using PostStore.Data.SQL;

namespace PostStore.Data.Repositories
{
    public class PackageRepository : IRepository<Package>
    {
        #region Fields

        private PostStoreDbContext dbContext;

        #endregion

        #region Constructors

        public PackageRepository(PostStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #endregion

        #region IRepository implementation

        public Package CreateNew()
        {
            return dbContext.Packages.Create();
        }

        public IEnumerable<Package> All()
        {
            return dbContext.Packages.AsEnumerable();
        }

        public void AddNew(Package item)
        {
            dbContext.Packages.Add(item);
            dbContext.SaveChanges();
        }

        public void Update(Package item)
        {
            dbContext.Entry<Package>(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public Package GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveById(int id)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
