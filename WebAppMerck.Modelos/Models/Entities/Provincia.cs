using System.ComponentModel.DataAnnotations;

namespace WebAppMerck.Modelos.Models.Entities;

public class Provincia
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string NombreProvincia { get; set; } = null!;

    public virtual ICollection<Localidad> Localidades { get; set; } = new List<Localidad>();
}
