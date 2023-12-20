using System;
using System.Collections.Generic;

namespace WebAppMerck.Models.Entities;

public partial class Localidad
{
    public int Id { get; set; }

    public int? IdProvincia { get; set; }

    public string Localidades { get; set; } = null!;

    public virtual Provincia Provincia { get; set; }
}
