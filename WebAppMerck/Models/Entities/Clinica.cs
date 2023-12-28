using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAppMerck.Models.Entities;

public partial class Clinica
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Direccion { get; set; }

    public decimal? Latitud { get; set; }

    public decimal? Longitud { get; set; }
    public string? Provincia { get; set; }
}
