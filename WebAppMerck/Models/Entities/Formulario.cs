using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppMerck.Models.Entities
{
    public class Formulario
    {
        [Key]
        public int Id { get; set; }
        public string Nombre { get; set; } = "";

        public string Apellido { get; set; } = "";

        public string Email { get; set; } = "";

        public int Edad { get; set; }

        public string Celular { get; set; } = "";

        public string Clinicas { get; set; } = "";

        public string Consulta { get; set; } = "";

        [Required(ErrorMessage = "La edad actual es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La edad actual debe ser un número mayor que cero.")]
        public int EdadActual { get; set; }
        [Required(ErrorMessage = "La edad de la primera menstruación es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La edad de la primera menstruación debe ser un número mayor que cero.")]
        public int EdadPrimeraMenstruacion { get; set; }
        public string? NivelFertilidad { get; set; } = "";
    }
}
