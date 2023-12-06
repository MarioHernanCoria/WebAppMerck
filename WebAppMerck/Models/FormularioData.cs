using System.ComponentModel.DataAnnotations;

namespace WebAppMerck.Models
{
    public class FormularioData
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "La edad actual es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La edad actual debe ser un número mayor que cero.")]
        public int EdadActual { get; set; }
        [Required(ErrorMessage = "La edad de la primera menstruación es requerida")]
        [Range(1, int.MaxValue, ErrorMessage = "La edad de la primera menstruación debe ser un número mayor que cero.")]
        public int EdadPrimeraMenstruacion { get; set; }
        public string? NivelFertilidad { get; set; } = "";
    }
}
