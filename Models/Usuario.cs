using System;
using System.Collections.Generic;

namespace Proveduria.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string? Correo { get; set; }

    public string? Contasena { get; set; }

    public string? TipoUsuario { get; set; }

    public string? NombreUsuario { get; set; }
}
