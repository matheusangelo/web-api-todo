using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Todo.Domain.Handlers;
using Todo.Domain.Infra.Repositories;
using Todo.Domain.Repositories;
using ToDo.Domain.Infra.Contexts;

namespace ToDo.Domain.Api
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
            services.AddControllers();
            services.AddDbContext<ToDoContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("connectionString")));
            
            //Contracts
            services.AddScoped<ITodoRepository,ToDoRepository>();


            //Handlers
            services.AddScoped<HandlerCreateToDoItem,HandlerCreateToDoItem>();
            services.AddScoped<HandlerMarkAsDone,HandlerMarkAsDone>();
            services.AddScoped<HandlerMakeTodoAsUndone,HandlerMakeTodoAsUndone>();
            services.AddScoped<HandlerUpdateToDoItem,HandlerUpdateToDoItem>();

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

            app.UseCors(x=>{
                x.AllowAnyHeader();
                x.AllowAnyMethod();
                x.AllowCredentials();
            });

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
