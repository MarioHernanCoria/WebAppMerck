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
        private readonly string _filePath;

        public ClinicasServicio(string filePath)
        {
            _filePath = filePath;
        }

        public List<ClinicasDto> ObtenerClinicasCsv()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    var csvContent = httpClient.GetStringAsync(_filePath).Result;

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
              Provincia = clinica.Provincia,

           }).ToList();

           return clinicasDirecciones;
        }  
    }
}
