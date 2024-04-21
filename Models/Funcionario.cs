using System;
using System.Collections.Generic;

namespace Proveduria;

public partial class Funcionario
{
    public int IdFuncionario { get; set; }

    public string? Identificacion { get; set; }

    public string? NombreFuncionario { get; set; }

    public string? CorreoFuncionario { get; set; }

    public string? Estado { get; set; }

    public string? Contraseña { get; set; }
}
