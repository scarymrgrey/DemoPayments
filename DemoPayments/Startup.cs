using CQRS.Data.Provider.EF;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Operations.Persistance;
using Incoding.Block.IoC;
using Incoding.CQRS;
using Incoding.Data;
using Microsoft.EntityFrameworkCore;

namespace DemoPayments
{
    public class Startup
    {
     

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(_ => Configuration);
            services.AddScoped<DbContext>(r => new IncDbContext(Configuration.GetConnectionString("Main"), MappingCollection<User>.Maps));
            services.AddScoped<IEntityFrameworkSessionFactory, EntityFrameworkSessionFactory>();
            services.AddScoped<IUnitOfWorkFactory,EntityFrameworkUnitOfWorkFactory>();
            services.AddTransient<IDispatcher,DefaultDispatcher>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
