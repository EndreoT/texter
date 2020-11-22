using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Texter.Domain.RepositoryInterface;
using Texter.Domain.RepositoryInterface.DeviceRepository;
using Texter.Domain.RepositoryInterface.MessageRepository;
using Texter.Domain.Services;
using Texter.Persistence.Context;
using Texter.Persistence.Repositories;
using Texter.Persistence.Repositories.DeviceRepository;
using Texter.Persistence.Repositories.MessageRepository;
using Texter.Services.DeviceService;
using Texter.Services.InMemoryService;
using Texter.Services.MessageServices;
using Texter.Middleware;


namespace Texter
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string dbConnectionStr = Configuration["Database:ConnectionString"];
            services.AddDbContext<AppDbContext>(
                item => item.UseMySql(dbConnectionStr)
                );

            services.AddControllers();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IInMemoryMessageService, InMemoryMessageService>();

            services.AddSwaggerGen();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseMiddleware<RequestLoggerMiddleware>();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
