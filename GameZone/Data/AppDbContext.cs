using GameZone.Models;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Game>Games { get; set; }
        public DbSet<Category>Categories { get; set; }
        public DbSet<Device>Devices { get; set; }
        public DbSet<GameDevice>GameDevices { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>()
                .HasData(new Category[]
                {
                    new Category{Id=1,Name="Sports"},
                    new Category{Id=2,Name="Action"},
                    new Category{Id=3,Name="Film"},
                    new Category{Id=4,Name="Racing"},
                    new Category{Id=5,Name="Wars"},
                    new Category{Id=6,Name="Adventure"},
                });

            modelBuilder.Entity<Device>()
                .HasData(new Device[]
                {
                    new Device{Id=1,Name="PlayStation",Icon="bi bi-playstation"},
                    new Device{Id=2,Name="xbox",Icon="bi bi-xbox"},
                    new Device{Id=3,Name="Pc",Icon="bi bi-pc-display"},
                    new Device{Id=4,Name="Nintendo",Icon="bi bi-nintendo-switch"}

                });

            modelBuilder.Entity<GameDevice>()
                .HasKey(e => new { e.DeviceId, e.GameId });

            base.OnModelCreating(modelBuilder);
        }

    }
}
