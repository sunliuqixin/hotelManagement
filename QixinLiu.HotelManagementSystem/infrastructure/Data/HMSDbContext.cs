using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace infrastructure.Data
{
    public class HMSDbContext: DbContext
    {
        public HMSDbContext(
            DbContextOptions<HMSDbContext> options
            ): base(options)
        {
                
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //specify Fluent API rules for your Entities
            modelBuilder.Entity<RoomType>(ConfigureRoomType);
            modelBuilder.Entity<Service>(ConfigureService);
            modelBuilder.Entity<Booking>(ConfigureBooking);
            modelBuilder.Entity<Room>(ConfigureRoom);
        }

        private void ConfigureRoom(EntityTypeBuilder<Room> builder)
        {
            builder.HasOne(r => r.RoomType).WithMany(rt => rt.Rooms).HasForeignKey(r => r.RTCode);
        }

        private void ConfigureBooking(EntityTypeBuilder<Booking> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.CName).HasMaxLength(20);
            builder.Property(b => b.Address).HasMaxLength(100);
            builder.Property(b => b.Phone).HasMaxLength(20);
            builder.Property(b => b.Email).HasMaxLength(40);
            builder.Property(b => b.Advance).HasColumnType("decimal(5,2)");
            builder.HasOne(b => b.Room).WithMany(r => r.Bookings).HasForeignKey(b => b.RoomNO);
        }

        private void ConfigureService(EntityTypeBuilder<Service> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.SDESC).HasMaxLength(50);
            builder.Property(rt => rt.Amount).HasColumnType("decimal(5,2)");
            builder.HasOne(s => s.Room).WithMany(r => r.Services).HasForeignKey(s => s.RoomNO);
        }

        private void ConfigureRoomType(EntityTypeBuilder<RoomType> builder)
        {
            builder.HasKey(rt => rt.Id);
            builder.Property(rt => rt.RTDESC).HasMaxLength(20);
            builder.Property(rt => rt.Rent).HasColumnType("decimal(5,2)");
            
        }



        public DbSet<Room> Rooms { get; set; }

        public DbSet<RoomType> RoomTypes { get; set; }

        public DbSet<Service> Services { get; set; }

        public DbSet<Booking> Bookings { get; set; }
    }
}
