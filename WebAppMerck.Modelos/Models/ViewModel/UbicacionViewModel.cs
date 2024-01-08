using CsvHelper.Configuration.Attributes;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace WebAppMerck.Modelos.Models.ViewModel
{
    public class UbicacionViewModel
    {
        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "Por favor, ingrese una dirección de correo electrónico válida.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo País es obligatorio.")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "El campo Consulta es obligatorio.")]
        public string Consulta { get; set; }

        public List<SelectListItem> Provincias { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Localidades { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Consultas { get; set; } = new List<SelectListItem>();
        public List<ClinicasDto> Clinicas { get; set; } = new List<ClinicasDto>();
        public List<SelectListItem> ClinicasItems { get; set; } = new List<SelectListItem>();
    }

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
