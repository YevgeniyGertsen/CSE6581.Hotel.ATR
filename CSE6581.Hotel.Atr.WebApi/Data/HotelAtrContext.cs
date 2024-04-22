﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using CSE6581.Hotel.Atr.WebApi.Models;

namespace CSE6581.Hotel.Atr.WebApi.Data
{
    public partial class HotelAtrContext : DbContext
    {
        public HotelAtrContext()
        {
        }

        public HotelAtrContext(DbContextOptions<HotelAtrContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Room> Rooms { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("data source=178.89.186.221, 1434;initial catalog=TestAppDb;user id=TestAppUser;password=8Kq*rp781;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("TestAppUser");

            modelBuilder.Entity<Room>(entity =>
            {
                entity.Property(e => e.PathToImage).HasDefaultValueSql("(N'')");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
