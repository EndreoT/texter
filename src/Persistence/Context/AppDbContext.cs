using Microsoft.EntityFrameworkCore;

using Texter.Domain.Models;

namespace Texter.Persistence.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Message> Messages { get; set; }
        public DbSet<Device> Devices { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Device>().HasIndex(b => b.Address).IsUnique();

            Device device1 = new Device { DeviceId = 1, Address = "1234" };
            Device device2 = new Device { DeviceId = 2, Address = "5678" };
            builder.Entity<Device>().HasData
            (
                device1,
                device2
                
            );

            builder.Entity<Message>().HasData
            (
                new Message
                {
                    MessageId = 100,
                    Content = "Apple",
                    SourceAddr = device1.Address,
                    DestinationAddr = device2.Address
                },
                new Message
                {
                    MessageId = 103,
                    Content = "hi",
                    SourceAddr = device2.Address,
                    DestinationAddr = device1.Address
                }
            );
        }
    }
}