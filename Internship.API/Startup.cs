using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internship.API.Repositories;
using Internship.API.Repositories.Interfaces;
using Internship.API.Services;
using Internship.API.Services.Interfaces;
using Intership.API.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace Internship.API
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
            // requires using Microsoft.Extensions.Options
            services.Configure<SourceSCDatabaseSettings>(
                Configuration.GetSection(nameof(SourceSCDatabaseSettings)));

            services.AddSingleton<ISourceSCDatabaseSettings>(sp =>
                sp.GetRequiredService<IOptions<SourceSCDatabaseSettings>>().Value);

            services.AddSingleton(typeof(IUserRepository), typeof(UserRepository));
            services.AddSingleton(typeof(IUserService), typeof(UserService));

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
