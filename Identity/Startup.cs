using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Identity.Interfaces;
using Identity.Services;
using Identity.Models;
using Identity.Providers;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Identity
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            LoadAppConfigurations();
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer();
            services.AddControllers();
            services.AddAuthentication();

            services.AddSingleton<IUserService, UserService>();
            services.AddSingleton<IAuthService, AuthService>();
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

        private void LoadAppConfigurations()
        { 
            string configFileSrc = this.Configuration.GetValue<string>("ConfigFileLocation");
            var configFileJsonString = File.ReadAllText(configFileSrc);
            dynamic configFileObj = Newtonsoft.Json.JsonConvert.DeserializeObject(configFileJsonString);

            AppSettingsProvider.DbConnectionString = configFileObj.DbConnectionString;
            AppSettingsProvider.DbName = configFileObj.DbName;
        }
    
    }
}
