using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LearningProject2.Models;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Band> Bands { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Band>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

   
    }

    
}
