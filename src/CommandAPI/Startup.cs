using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CommandAPI.Data;
using Npgsql; 

namespace CommandAPI
{
    public class Startup
    {
        //Page 140
        public IConfiguration Configuration {get;}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Page 187
            var builder = new NpgsqlConnectionStringBuilder(); 
            builder.ConnectionString = 
                Configuration.GetConnectionString("PostgreSqlConnection");
            builder.Username = Configuration["UserId"];
            builder.Password = Configuration["Password"];
            
            //Page 142
            services.AddDbContext<CommandContext>(opt => opt.UseNpgsql
                (builder.ConnectionString));

            //Page 52 - Section 1.  Add code below
            services.AddControllers();

            //Page 102 add
            //Page 160 remove
            //services.AddScoped<ICommandAPIRepo, MockCommandAPIRepo>(); 
            //Page 160 add
            services.AddScoped<ICommandAPIRepo, SqlCommandAPIRepo>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //Page 52 stop host from listening
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World! Matt's system is working!");
                //});

                //Page 52 - Section 2 Add code below
                endpoints.MapControllers(); 
            });
        }
    }
}
