﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Texter.Persistence.Context;

namespace Texter.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Texter.Domain.Models.Device", b =>
                {
                    b.Property<long>("DeviceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Address")
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.HasKey("DeviceId");

                    b.HasIndex("Address")
                        .IsUnique();

                    b.ToTable("Devices");

                    b.HasData(
                        new
                        {
                            DeviceId = 1L,
                            Address = "1234"
                        },
                        new
                        {
                            DeviceId = 2L,
                            Address = "5678"
                        });
                });

            modelBuilder.Entity("Texter.Domain.Models.Message", b =>
                {
                    b.Property<long>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    b.Property<string>("Content")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("DestinationAddr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SourceAddr")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("MessageId");

                    b.ToTable("Messages");

                    b.HasData(
                        new
                        {
                            MessageId = 100L,
                            Content = "Apple",
                            DestinationAddr = "5678",
                            SourceAddr = "1234"
                        },
                        new
                        {
                            MessageId = 103L,
                            Content = "hi",
                            DestinationAddr = "1234",
                            SourceAddr = "5678"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
