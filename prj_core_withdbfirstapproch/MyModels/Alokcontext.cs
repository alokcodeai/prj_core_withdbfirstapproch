using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace prj_core_withdbfirstapproch.MyModels;

public partial class Alokcontext : DbContext
{
    public Alokcontext()
    {
    }

    public Alokcontext(DbContextOptions<Alokcontext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<CustomerAddress> CustomerAddresses { get; set; }

    public virtual DbSet<CustomerBank> CustomerBanks { get; set; }

    public virtual DbSet<Difficulty> Difficulties { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Region> Regions { get; set; }

    public virtual DbSet<Walk> Walks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //    => optionsBuilder.UseSqlServer("name=DBconnection");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CustomerAddress>(entity =>
        {
            entity.HasOne(d => d.Cust).WithMany(p => p.CustomerAddresses).HasConstraintName("FK_customer_address_customer");
        });

        modelBuilder.Entity<CustomerBank>(entity =>
        {
            entity.HasOne(d => d.Cust).WithMany(p => p.CustomerBanks).HasConstraintName("FK_customer_bank_customer");
        });

        modelBuilder.Entity<Difficulty>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Region>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        modelBuilder.Entity<Walk>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
