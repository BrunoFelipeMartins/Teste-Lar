using Microsoft.EntityFrameworkCore;
using WebApiLar.Infra.Database.Models;

namespace WebApiLar.Infra.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person>? people { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=testLar;Pooling=true;");
    }
}