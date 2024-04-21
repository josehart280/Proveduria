using System;
using System.Collections.Generic;

namespace Proveduria;

public partial class ImpuestosMensuales
{
    public int IdImpuestoMensual { get; set; }

    public int? Mes { get; set; }

    public int? Año { get; set; }

    public decimal? Monto { get; set; }

    public string? Tipo { get; set; }
}
