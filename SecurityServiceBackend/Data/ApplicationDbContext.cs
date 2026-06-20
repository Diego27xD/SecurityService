using Microsoft.EntityFrameworkCore;
using SecurityServiceBackend.Models;

namespace SecurityServiceBackend.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");
                entity.HasIndex(u => u.NombreUsuario).IsUnique();
            });
        }
    }
}
