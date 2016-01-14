using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SQLite;

namespace PostStore.Data
{
    public class SQLiteConnectionFactory : IDbConnectionFactory
    {
        private static SQLiteConnectionFactory instance;

        public static SQLiteConnectionFactory Instance
        {
            get
            {
                return instance ?? (instance = new SQLiteConnectionFactory());
            }
        }

        public DbConnection CreateConnection(string nameOrConnectionString) => new SQLiteConnection(nameOrConnectionString);
    }
}
