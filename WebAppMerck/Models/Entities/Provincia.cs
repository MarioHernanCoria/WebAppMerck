using System;
using System.Collections.Generic;

namespace WebAppMerck.Models.Entities;

public partial class Provincia
{
    public int Id { get; set; }

    public string Provincias { get; set; } = null!;

    public virtual ICollection<Localidad> Localidades { get; set; } = new List<Localidad>();
}
