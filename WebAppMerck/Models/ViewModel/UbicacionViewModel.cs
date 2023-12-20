using Microsoft.AspNetCore.Mvc.Rendering;
using WebAppMerck.Models.DTOs;
using WebAppMerck.Models.Entities;

namespace WebAppMerck.Models.ViewModel
{
    public class UbicacionViewModel
    {
        public string Email { get; set; }
        public string Pais { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }
        public string Consulta { get; set; }
        public string ProvinciaSeleccionada { get; set; }
        public List<SelectListItem> Provincias { get; set; }
        public List<SelectListItem> Localidades { get; set; }
        public List<SelectListItem> Consultas { get; set; }
        public List<ClinicasDto> Clinicas { get; set; }
        public List<SelectListItem> ClinicasItems { get; set; }

    }
}
