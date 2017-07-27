using Incoding.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Infrastructure;

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
            return new IncDbContext("Data Source=.;Initial Catalog=Main;User ID=sa;Password=win20033;");
        }
    }
}
