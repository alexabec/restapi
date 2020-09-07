using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using kwiqstage.Models;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using Stripe;

namespace kwiqstage
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
            services.AddDbContext<kwiq_prodContext>(options =>
                options.UseMySql(
                    Configuration["ConnectionStrings:DefaultConnection"],
                    mySqlOptions =>
                    {
                        mySqlOptions.ServerVersion(new Version(5, 7, 27), ServerType.MySql); // replace with your Server Version and Type
                    }
                )
            );

             StripeConfiguration.ApiKey = "sk_test_51GwujkITcigAAz2ynDly622Ld0sVPgfHpwS4HoZgdRvEP0K7JXUENWepv7Yvr48obDvHlIXgseR9kFhZL8HwF5Dh00gCNT7Pth";

            services.AddControllers();

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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
