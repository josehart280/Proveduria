using System;
using System.Collections.Generic;

namespace Proveduria;

public partial class roles
{
    public int IdRol { get; set; }

    public string? NombreRol { get; set; }

    public bool? EstadoRol { get; set; }

    public virtual ICollection<Usuarios> Usuario1s { get; set; } = new List<Usuarios>();
}
