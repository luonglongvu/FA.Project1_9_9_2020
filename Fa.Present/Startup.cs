using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FA.Core.Model;
using FA.Core.Repository;
using FA.Core.Services;
using FA.Project.Model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Fa.Present
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
            services.AddDbContext<TMSContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("TodoConn")));
            services.AddControllersWithViews();
            services.AddScoped<IGenericRepository<Trainee>, GenericRepository<Trainee>>();
            services.AddScoped<ITraineeRepository, TraineeRepository>();

            services.AddScoped<IBaseService<Trainee>, BaseService<Trainee>>();
            services.AddScoped<ITraineeServices, TraineeServices>();

            services.AddScoped<IGenericRepository<Request>, GenericRepository<Request>>();
            services.AddScoped<IRequestRepository, RequestRepository>();

            services.AddScoped<IBaseService<Request>, BaseService<Request>>();
            services.AddScoped<IRequestServices, RequestServices>();
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,TMSContext context)
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
                 name: "areas",
                 pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
             );
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            DbInitializer.Seed(context);
        }
    }
}
