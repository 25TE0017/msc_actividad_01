using actividad01.Models;
using Microsoft.EntityFrameworkCore;

namespace actividad01.Data
{
    public class AppDbContext: DbContext
    {
         public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Alumno> Alumnos { get; set; }
        public DbSet<Mantenimiento> Mantenimientos { get; set; }
        public DbSet<Archivo> Archivos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Alumno>()
                .HasKey(a => a.NoControl);

            modelBuilder.Entity<Mantenimiento>()
                .HasKey(a => a.Id);

            modelBuilder.Entity<Archivo>()
                .HasKey(a => a.Id);
        }
        
    }
}

// dotnet ef migrations add InitialCreate
// dotnet ef database update
// dotnet ef migrations list
// dotnet ef migrations remove
// dotnet ef migrations add NombreMigracion
// dotnet ef migrations script