    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using WebApplication1d.Models;

namespace WebApplication1d.Contexts;

public class BlogDbContext : IdentityDbContext
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
            ImagePath = "img\\SliderIMG\\w4ris3ke.sao35456416613473181A7A9120 (1).jpg"
        }
       );
        base.OnModelCreating(modelBuilder);


    }

}

