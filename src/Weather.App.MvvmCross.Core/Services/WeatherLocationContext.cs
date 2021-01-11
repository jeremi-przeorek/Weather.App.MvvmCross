using System.IO;
using Microsoft.EntityFrameworkCore;
using Weather.App.MvvmCross.Core.Models;

namespace Weather.App.MvvmCross.Core.Services
{
    public class WeatherLocationContext : DbContext
    {
        public DbSet<WeatherLocation> WeatherLocations { get; set; }

        public WeatherLocationContext()
        {
            SQLitePCL.Batteries_V2.Init();

            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var location = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            optionsBuilder
                .UseSqlite($"Filename={location}/weatherLocations.db3");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
