using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PostStore.Data.Models;
using PostStore.Data.Repositories.Interfaces;
using PostStore.Data.SQL;

namespace PostStore.Data.Repositories
{
    public class PostEntryRepository : IRepository<PostEntry>
    {
        readonly PostStoreDbContext dbContext;

        public PostEntryRepository(PostStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region IRepository implementation

        public PostEntry GetById(int id)
        {
            return dbContext.PostEntries.FirstOrDefault(x => x.TSDocId == id);
        }

        public PostEntry CreateNew()
        {
            return dbContext.PostEntries.Create();
        }

        public void AddNew(PostEntry item)
        {
            dbContext.PostEntries.Add(item);
            dbContext.SaveChanges();
        }

        public void RemoveById(int id)
        {
            dbContext.PostEntries.Remove(GetById(id));
            dbContext.SaveChanges();
        }

        public void Update(PostEntry item)
        {
            dbContext.Entry(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        public IEnumerable<PostEntry> All()
        {
            return dbContext.PostEntries.AsEnumerable();
        }

        #endregion
    }
}
