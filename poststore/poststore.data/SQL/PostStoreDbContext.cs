using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using PostStore.Data.Models;
using System.Data.Common;
using SQLite.CodeFirst;

namespace PostStore.Data.SQL
{
    [DbConfigurationType(typeof(SQLiteConfiguration))]
    public class PostStoreDbContext : DbContext
    {
        #region Static

        private static readonly string ConnectionString;

        static PostStoreDbContext()
        {
            var connectionStringBuilder = new DbConnectionStringBuilder();
            connectionStringBuilder.ConnectionString = "Data Source=|DataDirectory|PostStore.sqlite";
            ConnectionString = connectionStringBuilder.ToString();
        }

        #endregion

        #region Properties

        public DbSet<PostEntry> PostEntries { get; set; }

        public DbSet<Package> Packages { get; set; }

        public DbSet<PostType> PostTypes { get; set; }

        #endregion

        #region Constructors

        public PostStoreDbContext() : base(ConnectionString)
        {
            Configuration.ProxyCreationEnabled = true;
            Configuration.LazyLoadingEnabled = true;
        }

        #endregion

        #region Overriden

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new SqliteCreateDatabaseIfNotExists<PostStoreDbContext>(modelBuilder));
        }

        #endregion
    }
}
