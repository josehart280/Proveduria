using System;
using System.Collections.Generic;

namespace Proveduria;

public partial class Cliente
{
    public int IdCliente { get; set; }

    public string? NombreCliente { get; set; }

    public string? Identificacion { get; set; }

    public string? Tipo { get; set; }

    public string? DireccionCliente { get; set; }

    public string? TelefonoCliente { get; set; }

    public string? CorreoCliente { get; set; }

    public virtual ICollection<FacturasVenta> FacturasVenta { get; set; } = new List<FacturasVenta>();
}
