using CsvHelper.Configuration.Attributes;

namespace WebAppMerck.Models.DTOs
{
    public class ClinicasDto
    {
        [Name("nombre")]
        public string Nombre { get; set; }
        [Name("direccion")]
        public string Direccion { get; set; }
        [Name("latitud")]
        public double Latitud { get; set; }
        [Name("longitud")]
        public double Longitud { get; set; }
    }
}
