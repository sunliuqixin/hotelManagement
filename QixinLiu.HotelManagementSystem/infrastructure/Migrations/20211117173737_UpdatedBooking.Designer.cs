﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using infrastructure.Data;

namespace infrastructure.Migrations
{
    [DbContext(typeof(HotelMangageDb))]
    [Migration("20211117173737_UpdatedBooking")]
    partial class UpdatedBooking
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.11")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ApplicationCore.Entities.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("Advance")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int?>("BookingDays")
                        .HasColumnType("int");

                    b.Property<string>("CName")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<DateTime?>("CheckIn")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("RoomNO")
                        .HasColumnType("int");

                    b.Property<int?>("TotalPersons")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoomNO");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("RTCode")
                        .HasColumnType("int");

                    b.Property<bool?>("Status")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("RTCode");

                    b.ToTable("Room");
                });

            modelBuilder.Entity("ApplicationCore.Entities.RoomType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("RTDESC")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<decimal?>("Rent")
                        .HasColumnType("decimal(5,2)");

                    b.HasKey("Id");

                    b.ToTable("RoomType");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(5,2)");

                    b.Property<int?>("RoomNO")
                        .HasColumnType("int");

                    b.Property<string>("SDESC")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("ServiceDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("RoomNO");

                    b.ToTable("Service");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Booking", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Room", "Room")
                        .WithMany("Bookings")
                        .HasForeignKey("RoomNO");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Room", b =>
                {
                    b.HasOne("ApplicationCore.Entities.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RTCode");

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Service", b =>
                {
                    b.HasOne("ApplicationCore.Entities.Room", "Room")
                        .WithMany("Services")
                        .HasForeignKey("RoomNO");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("ApplicationCore.Entities.Room", b =>
                {
                    b.Navigation("Bookings");

                    b.Navigation("Services");
                });

            modelBuilder.Entity("ApplicationCore.Entities.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
