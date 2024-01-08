using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMerck.Modelos.Models.Entities;

public class Clinica
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string NombreClinica { get; set; }

    [Required]
    public string Direccion { get; set; }

    [Required]
    public double Latitud { get; set; }

    [Required]
    public double Longitud { get; set; }

    [Required]
    public string NombreProvincia { get; set; }
    public int ProvinciaId { get; set; }

    [ForeignKey("ProvinciaId")]
    public virtual Provincia Provincia { get; set; }
}
