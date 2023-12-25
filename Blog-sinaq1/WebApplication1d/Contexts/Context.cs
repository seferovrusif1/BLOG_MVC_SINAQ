﻿    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using WebApplication1d.Models;

namespace WebApplication1d.Contexts;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Setting> Settings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Seeding Country Master Data using HasData method
        modelBuilder.Entity<Setting>().HasData(new Setting()
        {
            id = 1,
            ImagePath = "IND"
        }
       );
        base.OnModelCreating(modelBuilder);


    }

}

