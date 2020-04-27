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

            builder.Entity<Device>().HasMany(d => d.SentMessages)
                .WithOne(m => m.SourceAddr)
                .HasForeignKey(m => m.SourceAddrDeviceId);

            builder.Entity<Device>().HasMany(d => d.ReceiveMessages)
                .WithOne(m => m.DestinationAddr)
                .HasForeignKey(m => m.DestinationAddrDeviceId)
                //.OnDelete(DeleteBehavior.Restrict)
                ;

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
                    SourceAddrDeviceId = device1.DeviceId,
                    DestinationAddrDeviceId = device2.DeviceId
                },
                new Message
                {
                    MessageId = 103,
                    Content = "hi",
                    SourceAddrDeviceId = device2.DeviceId,
                    DestinationAddrDeviceId = device1.DeviceId
                }
            );
        }
    }
}