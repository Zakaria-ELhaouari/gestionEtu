using firstPrjAspCore.Models;
using firstPrjAspCore.Models.RepositorIes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
//using Microsoft.EntityFrameworkCore.SqlServer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstPrjAspCore
{
    public class Startup
    {
        //dependancie injection
        IConfiguration _confige;

        public Startup(IConfiguration confige)
        {
            _confige = confige;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(options => options.EnableEndpointRouting = false).AddXmlSerializerFormatters();
            //services.AddSingleton<ISchool<Etudiant> , EtudiantRepository>();
            services.AddScoped<ISchool<Etudiant>, EtudiantsDbRepository>();
            services.AddDbContext<GestionEtuDbContext>(options =>
            {
                options.UseSqlServer(_confige.GetConnectionString("SqlCon"));
            });
                
        }

        private void options(DbContextOptionsBuilder obj)
        {
            throw new NotImplementedException();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }

            //app.UseRouting();
            //DefaultFilesOptions defaultFile = new DefaultFilesOptions();
            //defaultFile.DefaultFileNames.Clear();
            //defaultFile.DefaultFileNames.Add("zack.html");
            //app.UseDefaultFiles(defaultFile);
            //app.UseStaticFiles();
            //FileServerOptions serverOptions = new FileServerOptions();
            //serverOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //serverOptions.DefaultFilesOptions.DefaultFileNames.Add("zack.html");
            app.UseFileServer();
            //app.UseMvcWithDefaultRoute();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("kkkk");
            //});
            app.UseMvc(route =>
            {
                route.MapRoute("default", "{controller=Etudiant}/{action=index}/{id?}");
            });
            //app.Use(async(context,neext)=> {
            //    await context.Response.WriteAsync("hello §§§");
            //    await neext();
            //});

            //app.Use(async (context , next) =>
            //{
            //    await context.Response.WriteAsync("hello §§§");
            //    await next();
            //});

            //app.Run(async (context) =>{
            //    await context.Response.WriteAsync("finsh");
            //});
            //app.Use(async (context, next) =>
            //{
            //    await context.Response.WriteAsync("hello §§§");
            //    await next();
            //});
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        string message = _confige["key1"];
            //        await context.Response.WriteAsync(message);
            //    });
            //});
        }
    }
}
