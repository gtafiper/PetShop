using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApplicationService2;
using Core.DomainService2;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Petshop.Core.Entity;
using Petshop.Inferstructur.Data;
using Petshop.Inferstructur.Data.Reposetory;
using Petshop.Inferstructur.SQL;


namespace Pets.Api.Conroller
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
            /*services.AddDbContext<Context>( opt => opt.UseInMemoryDatabase("Database"));
             */
            services.AddDbContext<Context>(
                opt => opt.UseSqlite("Data Source=PetShop.db"));
            services.AddScoped<IPetService, PetServices>();
            services.AddScoped<IOwnerService, OwnerService>();
            services.AddScoped<IPetRepository, PetReposetory>();
            services.AddScoped<iOwnerReposetory, OwnerReposetory>();
            

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                
                app.UseDeveloperExceptionPage();
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var ctx = scope.ServiceProvider.GetService<Context>();
                    DbSeeder.seedDb(ctx);
                }
            }
            else
            {
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
