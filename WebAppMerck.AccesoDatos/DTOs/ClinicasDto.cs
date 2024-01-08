using CsvHelper.Configuration.Attributes;

namespace WebAppMerck.AccesoDatos.DTOs
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
        [Name("provincia")]
        public string Provincia { get; set; }
        
    }
}
