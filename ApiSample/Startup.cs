using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSample.DAL;
using ApiSample.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace ApiSample
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
            services.AddDbContext<API_hotelContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DbContext"));
            });

            services.AddTransient<IExampleService, EntityFrameworkExampleService>();
            services.AddControllers()
                .AddNewtonsoftJson(Options =>
                {
                    Options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                }); 
        // biblioteka s³u¿¹ca do serializacji jsonów - do t³umaczenia listy obiektów na jsona
        // s³u¿y do ignorowania pêtli
        // nale¿y doinstalowaæ NewtonsoftJson. W Package Manager Console: 
        // Install-Package Microsoft.AspNetCore.Mvc.NewtonsoftJson
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
