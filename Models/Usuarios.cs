using System;
using System.Collections.Generic;

namespace Proveduria;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public string? Identificacion { get; set; }

    public string? NombreFuncionario { get; set; }

    public string? CorreoFuncionario { get; set; }

    public string? Estado { get; set; }

    public string? Contraseña { get; set; }

    public int? IdRol { get; set; }

    public virtual roles? IdRolNavigation { get; set; }
}
