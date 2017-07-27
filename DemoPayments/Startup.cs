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
        void configureIoC()
        {
            IoCFactory.Instance.Initialize(init => init.WithProvider(new SimpleInjectorIoCProvider(container =>
            {
                container.Register<IDispatcher>(()=> new DefaultDispatcher());
                container.Register<IUnitOfWorkFactory>(() => new EntityFrameworkUnitOfWorkFactory(new EntityFrameworkSessionFactory(()=> new IncDbContext(Configuration.GetConnectionString("Main"), typeof(User).Assembly))));
            })));
        }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            configureIoC();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton(_ => Configuration);
            services.AddDbContext<IncDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Main")));
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
