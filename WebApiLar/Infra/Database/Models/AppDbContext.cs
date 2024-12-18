using Microsoft.EntityFrameworkCore;
using WebApiLar.Infra.Database.Models;

namespace WebApiLar.Infra.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person>? people { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("User ID=postgres;Password=postgres;Host=localhost;Port=5432;Database=testLar;Pooling=true;");
    

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(p => p.idPerson);
                entity.Property(p => p.idPerson).ValueGeneratedOnAdd(); // Gera ID automaticamente
                entity.Property(p => p.name).IsRequired();
                entity.Property(p => p.cpf).IsRequired();
                entity.Property(p => p.dateBirth).IsRequired();
                entity.Property(p => p.active).IsRequired();
            });
        }
    }
}