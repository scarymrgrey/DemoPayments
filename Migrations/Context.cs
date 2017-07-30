using CQRS.Data.Provider.EF;
using Incoding.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Operations.Persistance;

namespace Migrations
{
    public class Program
    {
        public static void Main(string[] args)
        {
        }
    }
    public class TemporaryDbContextFactory : IDesignTimeDbContextFactory<IncDbContext>
    {
        public IncDbContext CreateDbContext(string[] args)
        {
            return new IncDbContext("Data Source=.;Initial Catalog=Main;User ID=sa;Password=win20033;", MappingCollection<User>.Maps);
        }
    }
}
