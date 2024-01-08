using Microsoft.EntityFrameworkCore;
using WebAppMerck.Modelos.Models.Entities;

namespace WebAppMerck.DataAccess.Data.DatabaseSeeding
{
    public class ClinicaSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Clinica>().HasData(
                    new 
                    {
                        Id = 1,
                        NombreClinica = "CEGYR Medicina Reproductiva",
                        Direccion = "Viamonte 1432",
                        Latitud = -34.6007441,
                        Longitud = -58.3871741,
                        NombreProvincia = "Capital Federal",
                        ProvinciaId = 3
                    },
                    new
                    {
                        Id = 2,
                        NombreClinica = "CER",
                        Direccion = "Humboldt 2263",
                        Latitud = -34.5806714,
                        Longitud = -58.4302438,
                        NombreProvincia = "Catamarca",
                        ProvinciaId = 4
                    },
                    new
                    {
                        Id = 3,
                        NombreClinica = "Centro de Investigaciones en Medicina Reproductiva",
                        Direccion = "Av.Forest 1166",
                        Latitud = -34.5788222,
                        Longitud = -58.4600967,
                        NombreProvincia = "Chaco",
                        ProvinciaId = 4
                    },
                    new
                    {
                        Id = 4,
                        NombreClinica = "Centro Gens",
                        Direccion = "Alvear 514",
                        Latitud = -34.7197709,
                        Longitud = -58.2562604,
                        NombreProvincia = "Chubut",
                        ProvinciaId = 5
                    },
                    new
                    {
                        Id = 5,
                        NombreClinica = "Halitus Instituto Médico",
                        Direccion = "Marcelo T. de Alvear 2084",
                        Latitud = -34.5974643,
                        Longitud = -58.3971746,
                        NombreProvincia = "Capital Federal",
                        ProvinciaId = 3
                    },
                    new
                    {
                        Id = 6,
                        NombreClinica = "Maternity Bank",
                        Direccion = "Bulnes 1104",
                        Latitud = -34.5983000,
                        Longitud = -58.4179000,
                        NombreProvincia = "Capital Federal",
                        ProvinciaId = 3
                    },
                    new 
                    {
                        Id = 7,
                        NombreClinica = "WeFIV",
                        Direccion = "Av. del Libertador 5962",
                        Latitud = -34.5571000,
                        Longitud = -58.4476000,
                        NombreProvincia = "Capital Federal",
                        ProvinciaId = 3
                    });
        }
    }
}
