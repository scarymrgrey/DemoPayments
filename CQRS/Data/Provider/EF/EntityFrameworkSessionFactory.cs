namespace Incoding.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;

    public class EntityFrameworkSessionFactory : IEntityFrameworkSessionFactory
    {
        [ThreadStatic]
        static DbContext currentSession;

        readonly DbContext createDb;

        public EntityFrameworkSessionFactory(DbContext createDb)
        {
            this.createDb = createDb;
        }

        public DbContext Open(string connectionString)
        {
            currentSession = createDb;
            return currentSession;
        }
    }
}