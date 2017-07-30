using CQRS.Data.Provider.EF;

namespace Incoding.Data
{
    using System;
    using System.Collections.Generic;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Reflection;
    using Incoding.Extensions;

    public class IncDbContext : DbContext
    {

        readonly List<Type> mapsTypes;
        readonly string connectionString;

        public IncDbContext(string nameOrConnectionString, List<Type> mapAssemblyTypes)
        {
            mapsTypes = mapAssemblyTypes;
            connectionString = nameOrConnectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString, b => b.MigrationsAssembly("Migrations"));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var mapsType in this.mapsTypes)
            {
                var map = Activator.CreateInstance(mapsType) as IEFClassMap;
                map.OnModelCreating(modelBuilder);
            }
        }
    }
}