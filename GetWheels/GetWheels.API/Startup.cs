using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetWheels.Data;
using GetWheels.Data.Contracts;
using GetWheels.Data.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;

namespace GetWheels.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<GWContextDb>(options => options
                .UseMySql(Configuration.GetConnectionString("Default"),
                    b => b.MigrationsAssembly("GetWheels.API")));

            services.AddTransient<IUserRepository, UserRepository>();

            services.AddMvc()
                    .AddJsonOptions(options => 
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }

            app.UseMvc();
        }
    }
}
