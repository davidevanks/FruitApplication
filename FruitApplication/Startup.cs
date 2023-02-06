using BusinessLogic;
using DataAccess.Models;
using DataAccess.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FruitApplication
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
            services.AddControllers();
            string DBUUID = Guid.NewGuid().ToString();
            services.AddDbContext<FruitContext>(opt =>
                opt.UseInMemoryDatabase("FruitList" + DBUUID));
            services.AddControllers();
            services.AddScoped<IFruitRepository, FruitRepository>();

            services.AddScoped<IBLFruit, IBLFruit>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            //using var scope = app.ApplicationServices.CreateScope();
            //FruitContext context = scope.ServiceProvider.GetRequiredService<FruitContext>();
            //AddTestData(context);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        //private static void AddTestData(FruitContext context)
        //{
        //    var ft = new FruitType
        //    {
                
        //        Name="Citricos",
        //        Description="Citricos del campo"
        //    };

        //    context.FruitTypes.Add(ft);
        //    context.SaveChanges();
      
        //}


    }
}
