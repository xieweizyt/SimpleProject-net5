using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extras.DynamicProxy;
using IOC.BLL;
using IOC.CustomerIOC;
using IOC.IBLL;
using Microsoft.AspNetCore.Mvc.Controllers;
using simple_net5.Commom;

namespace simple_net5
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
            services.AddControllersWithViews().AddControllersAsServices();
            //var activator = services.FirstOrDefault(t => t.ServiceType == typeof(IControllerActivator));
            //services.Remove(activator);
            //services.AddTransient<IControllerActivator, CustomerControllerActivator>();
            //services.AddTransient<IPhone, Phone>();
            //services.AddTransient<IHeadphone, Headphone>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=AutoFacController1}/{action=Index}/{id?}");
            });
        }

        public void ConfigureContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<Phone>().As<IPhone>();

            containerBuilder.RegisterType<Headphone>()
                .As<IHeadphone>()
                //支持属性注入
                .PropertiesAutowired(new CustomPropertySelector())
                //支持方法注入
                .OnActivated(p =>
                {
                    p.Instance.SetValue(p.Context.Resolve<IPhone>());
                });

            //增加AOP
            //containerBuilder.RegisterType<Headphone>()
            //    .As<IHeadphone>()
            //    .EnableInterfaceInterceptors();
            //containerBuilder.RegisterType(typeof(CustomInterceptor));
        }
    }
}
