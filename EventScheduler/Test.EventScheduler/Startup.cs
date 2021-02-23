using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Test.EventScheduler.DataAccess;
using Test.EventScheduler.Filters;
using Test.EventScheduler.MapperConfigurations;
using Test.EventScheduler.Services;
using Test.EventScheduler.Services.Interfaces;

namespace Test.EventScheduler
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
            var connectionString = Configuration.GetConnectionString("ConnectionString");
            services.AddDbContext<EventSchedulerContext>(options => options.UseSqlServer(connectionString));

            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            services.AddSingleton(mapperConfig.CreateMapper());
            
            services.AddScoped<IDataContext>(p => p.GetService<EventSchedulerContext>());

            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IUserService, UserService>();

            services.AddControllers(options => options.Filters.Add(new HttpResponseExceptionFilter()));
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
