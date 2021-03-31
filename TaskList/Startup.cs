using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TaskList.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace TaskList
{
    public class Startup
    {
        readonly string MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers().AddNewtonsoftJson();
            services.AddDbContext<TaskDBContext>(options => {
                options.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=PLZ_work;Integrated Security=True;", options => options.EnableRetryOnFailure());


                services.AddCors();
                
                services.AddCors(options =>
                {
                    options.AddPolicy("Policy1",
                        builder =>
                        {
                            builder.WithOrigins("https://localhost:44381/",
                                                "https://localhost:57051/")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod();
                        });

                    options.AddPolicy("AnotherPolicy",
                        builder =>
                        {
                            builder.WithOrigins("https://localhost:44381/")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod();
                        });
                });
                
            });
            
            String connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<TaskDBContext>(opt => opt.UseSqlServer(connectionString));
            services.AddControllers();
            

        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            
            app.UseCors();
            app.UseCors(options => options.AllowAnyOrigin());  
            
            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {


                endpoints.MapGet("/echo",
                context => context.Response.WriteAsync("echo"))
                .RequireCors(MyAllowSpecificOrigins);

                endpoints.MapControllers()
                         .RequireCors(MyAllowSpecificOrigins);

                endpoints.MapGet("/echo2",
                    context => context.Response.WriteAsync("echo2"));

                





            });
        }
    }
}
