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
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using ScrumBoard.Data;
using ScrumBoard.Services;

namespace ScrumBoard.Web
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

            // UNTESTED
            services.AddCors();

            services.AddControllers();
            services.AddDbContext<ScrumBoardDbContext>(opts => {
                    opts.EnableDetailedErrors();
                    opts.UseNpgsql(Configuration.GetConnectionString("ScrumBoard"));
            });

            // transient = dispose of data between subsequent requests
            // scoped = lifetime of entire http request
            // singleton = only 1 instance will be used
            services.AddTransient<IBoardService, BoardService>();
            /*
            services.AddSwaggerGen(c => {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ScrumBoard.Web", Version = "v1" });
            });
            */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                //app.UseSwagger();
                //app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ScrumBoard.Web v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            // UNTESTED
            app.UseCors(builder => builder
                    .WithOrigins(
                        "http://localhost:5000"
                    )

                    .AllowAnyMethod()
                    .AllowAnyHeader()
            );

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}