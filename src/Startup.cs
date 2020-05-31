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

namespace Texter
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

            //services.AddDbContextPool<AppDbContext>(options => options
            //    // replace with your connection string
            //    .UseMySql("server=127.0.0.1;uid=root;pwd=1234;database=texter"
            //));
            services.AddDbContext<AppDbContext>(
                item => item.UseMySql(Configuration.GetConnectionString("DefaultConnection"))
                );

            services.AddControllers();
            services.AddScoped<IMessageRepository, MessageRepository>();
            services.AddScoped<IMessageService, MessageService>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<IDeviceService, DeviceService>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddSingleton<IInMemoryMessageService, InMemoryMessageService>();
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
