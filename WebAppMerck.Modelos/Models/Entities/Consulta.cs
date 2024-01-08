using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAppMerck.Modelos.Models.Entities;

public class Consulta
{
    [Key]
    public int Id { get; set; }

    public string MotivoConsulta { get; set; } = null!;

    public string Clinica { get; set; } = null!;

    public DateTime FechaYhora { get; set; }
    public Uri Url { get; set; }
}
