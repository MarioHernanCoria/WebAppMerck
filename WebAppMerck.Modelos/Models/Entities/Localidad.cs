using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMerck.Modelos.Models.Entities;
public class Localidad
{
    [Key]
    public int Id { get; set; }

    public int? IdProvincia { get; set; }
    [Required]
    public string NombreLocalidad { get; set; } = null!;

    [ForeignKey("IdProvincia")]
    public virtual Provincia Provincia { get; set; }
}
