using Microsoft.EntityFrameworkCore;
using WebAppMerck.Modelos.Models.Entities;

namespace WebAppMerck.DataAccess.Data.DatabaseSeeding
{
    public class ProvinciaSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Provincia>().HasData(
            new Provincia { Id = 1, NombreProvincia = "Buenos Aires" },
            new Provincia { Id = 2, NombreProvincia = "Buenos Aires-GBA" },
            new Provincia { Id = 3, NombreProvincia = "Capital Federal" },
            new Provincia { Id = 4, NombreProvincia = "Catamarca" },
            new Provincia { Id = 5, NombreProvincia = "Chaco" },
            new Provincia { Id = 6, NombreProvincia = "Chubut" },
            new Provincia { Id = 7, NombreProvincia = "Córdoba" },
            new Provincia { Id = 8, NombreProvincia = "Corrientes" },
            new Provincia { Id = 9, NombreProvincia = "Entre Ríos" },
            new Provincia { Id = 10, NombreProvincia = "Formosa" },
            new Provincia { Id = 11, NombreProvincia = "Jujuy" },
            new Provincia { Id = 12, NombreProvincia = "La Pampa" },
            new Provincia { Id = 13, NombreProvincia = "La Rioja" },
            new Provincia { Id = 14, NombreProvincia = "Mendoza" },
            new Provincia { Id = 15, NombreProvincia = "Misiones" },
            new Provincia { Id = 16, NombreProvincia = "Neuquén" },
            new Provincia { Id = 17, NombreProvincia = "Río Negro" },
            new Provincia { Id = 18, NombreProvincia = "Salta" },
            new Provincia { Id = 19, NombreProvincia = "San Juan" },
            new Provincia { Id = 20, NombreProvincia = "San Luis" },
            new Provincia { Id = 21, NombreProvincia = "Santa Cruz" },
            new Provincia { Id = 22, NombreProvincia = "Santa Fe" },
            new Provincia { Id = 23, NombreProvincia = "Santiago del Estero" },
            new Provincia { Id = 24, NombreProvincia = "Tierra del Fuego" },
            new Provincia { Id = 25, NombreProvincia = "Tucumán" }
        );
        }
    }
}
