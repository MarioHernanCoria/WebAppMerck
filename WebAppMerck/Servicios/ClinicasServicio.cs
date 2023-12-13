using CsvHelper;
using CsvHelper.Configuration;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.IO;
using WebAppMerck.Models.DTOs;

namespace WebAppMerck.Servicios
{
    public class ClinicasServicio
    {
        public async Task<List<ClinicasDto>> ObtenerClinicasCsv(string filePath)
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var csvContent = await httpClient.GetStringAsync(filePath);

                    using (var reader = new StringReader(csvContent))
                    using (var csv = new CsvReader(reader, new CsvConfiguration(CultureInfo.InvariantCulture)
                    {
                        HasHeaderRecord = true,
                    }))
                    {
                        return csv.GetRecords<ClinicasDto>().ToList();
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"No se obtuvieron las clínicas disponibles: {ex.Message}");
            }
        }


        public List<ClinicasDto> ConvertirClinicas(List<ClinicasDto> clinicas)
        {
           var clinicasDirecciones = clinicas.Select(clinica => new ClinicasDto
           {
              Nombre = clinica.Nombre,
              Direccion = clinica.Direccion,
              Latitud = clinica.Latitud,
              Longitud = clinica.Longitud,

           }).ToList();

           return clinicasDirecciones;
        }  
    }
}
