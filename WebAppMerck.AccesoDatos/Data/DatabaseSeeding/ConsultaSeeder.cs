using Microsoft.EntityFrameworkCore;
using WebAppMerck.Modelos.Models.Entities;


namespace WebAppMerck.DataAccess.Data.DatabaseSeeding
{
    public class ConsultaSeeder : IEntitySeeder
    {
        public void SeedDataBase(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Consulta>().HasData(
                    new
                    {
                        Id = 1,
                        MotivoConsulta = "Edad y Reserva Ovarica",
                        Clinica = "CEGYR Medicina Reproductiva",
                        FechaYhora = DateTime.Now,
                        Url = new Uri("https://ejemplo.com")
                    },
                    new
                    {
                        Id = 2,
                        MotivoConsulta = "Evaluación de Reserva Ovárica",
                        Clinica = "Centro de Investigaciones en Medicina Reproductiva",
                        FechaYhora = DateTime.Now,
                        Url = new Uri("https://ejemplo2.com")
                    });
        }
    }
}
