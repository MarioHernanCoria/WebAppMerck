using System.ComponentModel.DataAnnotations;

namespace WebAppMerck.Models
{
    public class FormularioData
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "La edad actual es requerida")]
        public int EdadActual { get; set; }
        [Required(ErrorMessage = "La edad de la primera menstruación es requerida")]
        public int EdadPrimeraMenstruacion { get; set; }
        public string NivelFertilidad { get; set; } 
    }
}
