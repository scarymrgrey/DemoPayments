using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using Operations.Persistance;
using CQRS.Data.Provider.NHibernate;

namespace DemoPayments
{
    public class Startup
    {
        void configureDataBase()
        {
            var configure = Fluently
                .Configure()
                .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(Configuration.GetConnectionString("Main")))
                .Mappings(configuration => configuration.FluentMappings
                    .AddFromAssembly(typeof(User).Assembly));
            var dbManager = new NhibernateManagerDataBase(configure);
                dbManager.Create();

        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            configureDataBase();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
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
