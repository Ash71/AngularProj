using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AngularProj.Mongo;
using AngularProj.Repositories;
using AngularProj.Services;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace AngularProj
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            return InitializeIOC(services);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
        }

        
        private IServiceProvider InitializeIOC(IServiceCollection services)
        {
            var builder = new ContainerBuilder();
            System.Reflection.Assembly entryAssembly = System.Reflection.Assembly.GetEntryAssembly();
            List<Assembly> assemblyList = new List<Assembly>();
            var assemblies = entryAssembly.GetReferencedAssemblies();
            foreach (var assembly in assemblies)
            {
                assemblyList.Add(System.Reflection.Assembly.Load(assembly));
            }            
            builder.RegisterType<ProductRepository>().As<IProductRepository>().InstancePerLifetimeScope();
            builder.RegisterType<ProductsService>().As<IProductsService>().InstancePerLifetimeScope();
            builder.RegisterType<DbProvider>().As<IDbProvider>().SingleInstance();


            builder.Populate(services);
            var container = builder.Build();
            return container.Resolve<IServiceProvider>();
        }
    }
}
