using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

using PostStore.Data.Models;
using PostStore.Data.Repositories.Interfaces;
using PostStore.Data.SQL;

namespace PostStore.Data.Repositories
{
    public class PostTypeRepository : IRepository<PostType>
    {
        private readonly PostStoreDbContext dbContext;

        public PostTypeRepository(PostStoreDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        #region IRepository implementation

        public PostType GetById(int id)
        {
            return dbContext.PostTypes.FirstOrDefault(x => x.Id == id);
        }

        public PostType CreateNew()
        {
            return dbContext.PostTypes.Create();
        }

        public IEnumerable<PostType> All()
        {
            return dbContext.PostTypes.AsEnumerable();
        }

        public void AddNew(PostType item)
        {
            dbContext.PostTypes.Add(item);
            dbContext.SaveChanges();
        }

        public void RemoveById(int id)
        {
            dbContext.PostTypes.Remove(GetById(id));
            dbContext.SaveChanges();
        }

        public void Update(PostType item)
        {
            dbContext.Entry<PostType>(item).State = EntityState.Modified;
            dbContext.SaveChanges();
        }

        #endregion
    }
}
