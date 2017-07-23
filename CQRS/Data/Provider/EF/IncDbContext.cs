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

        public IncDbContext(string nameOrConnectionString, Assembly mapAssembly)
                
        {
            this.mapsTypes = mapAssembly.GetTypes()
                                        .Where(r => r.IsImplement(typeof(EFClassMap<>)) &&
                                                    !r.IsInterface &&
                                                    !r.IsAbstract)
                                        .ToList();
            connectionString = nameOrConnectionString;
        }

        public IncDbContext(string nameOrConnectionString)
                : this(nameOrConnectionString, Assembly.GetCallingAssembly()) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
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