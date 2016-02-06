using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlLocalDb;
using System.Data.SqlClient;

namespace CleverClass.Common.Test
{
    public class TestDatabase<T> : IDisposable where T : DbContext
    {
        private readonly TemporarySqlLocalDbInstance _instance;

        public TestDatabase()
        {
            _instance = TemporarySqlLocalDbInstance.Create(true);
            using (var connection = _instance.CreateConnection())
            {
                connection.Open();
                using (var dbContext = CreateDbContext(connection))
                {
                    dbContext.Database.Initialize(true);
                }
            }
        }

        public void RunAndRollback(Action<T> test)
        {
            using (var connection = _instance.CreateConnection())
            {
                connection.Open();
                using (var dbContext = CreateDbContext(connection))
                {
                    using (var transaction = dbContext.Database.BeginTransaction())
                    {
                        try
                        {
                            test(dbContext);
                        }
                        finally
                        {

                            transaction.Rollback();
                        }
                    }
                }
            }
        }

        private static T CreateDbContext(SqlConnection connection)
        {
            return (T)Activator.CreateInstance(typeof(T), connection, false);
        }

        public void Dispose()
        {
            _instance.Dispose();
        }
    }
}
