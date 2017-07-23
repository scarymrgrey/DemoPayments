namespace Incoding.Data
{
    using System;
    using Microsoft.EntityFrameworkCore;

    public class EntityFrameworkSessionFactory : IEntityFrameworkSessionFactory
    {
        [ThreadStatic]
        static DbContext currentSession;

        readonly Func<DbContext> createDb;

        public EntityFrameworkSessionFactory(Func<DbContext> createDb)
        {
            this.createDb = createDb;
        }

        public DbContext Open(string connectionString)
        {
            currentSession = this.createDb();
            return currentSession;
        }
    }
}