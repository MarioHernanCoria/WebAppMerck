using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using WebAppMerck.Models.DTOs;
using WebAppMerck.Models.Entities;

namespace WebAppMerck.Models.ViewModel
{
    public class UbicacionViewModel
    {
        [Required(ErrorMessage = "El campo Email es obligatorio.")]
        [EmailAddress(ErrorMessage = "Por favor, ingrese una dirección de correo electrónico válida.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "El campo País es obligatorio.")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "El campo Provincia es obligatorio.")]
        public string Provincia { get; set; }

        [Required(ErrorMessage = "El campo Localidad es obligatorio.")]
        public string Localidad { get; set; }

        [Required(ErrorMessage = "El campo Consulta es obligatorio.")]
        public string Consulta { get; set; }
        public string ProvinciaSeleccionada { get; set; }
        public List<SelectListItem> Provincias { get; set; }
        public List<SelectListItem> Localidades { get; set; }
        public List<SelectListItem> Consultas { get; set; }
        public List<ClinicasDto> Clinicas { get; set; }
        public List<SelectListItem> ClinicasItems { get; set; }
    }
}
