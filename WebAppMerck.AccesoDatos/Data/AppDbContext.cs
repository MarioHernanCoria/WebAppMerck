using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAppMerck.DataAccess.Data.DatabaseSeeding;
using WebAppMerck.Modelos.Models.Entities;


namespace WebAppMerck.AccesoDatos.DataAccess
{
    public class AppDbContext : IdentityDbContext<Usuario>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Clinica> Clinicas { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var seeders = new List<IEntitySeeder>
            {
                new UsuarioSeeder(),
                new ConsultaSeeder(),
                new ClinicaSeeder(),
                new ProvinciaSeeder(),
                new LocalidadSeeder(),
            };
            foreach (var seeder in seeders)
            {
                seeder.SeedDataBase(modelBuilder);
            }
            base.OnModelCreating(modelBuilder);
        }
    }
}
