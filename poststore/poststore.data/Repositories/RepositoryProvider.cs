using PostStore.Data.Models;
using PostStore.Data.Repositories.Interfaces;
using PostStore.Data.SQL;

namespace PostStore.Data.Repositories
{
    public class RepositoryProvider
    {
        PostStoreDbContext dbContext;

        public RepositoryProvider()
        {
            dbContext = new PostStoreDbContext();
        }

        ~RepositoryProvider()
        {
            dbContext.Dispose();
        }

        public IRepository<PostEntry> PostEntries
        {
            get
            {
                return new PostEntryRepository(dbContext);
            }
        }

        public IRepository<PostType> PostTypes
        {
            get
            {
                return new PostTypeRepository(dbContext);
            }
        }

        public IRepository<Package> PackageRepository
        {
            get
            {
                return new PackageRepository(dbContext);
            }
        }
    }
}
