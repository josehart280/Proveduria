using System;
using System.Collections.Generic;

namespace Proveduria;

public partial class Proveedores
{
    public int IdProveedor { get; set; }

    public string? NombreProveedor { get; set; }

    public string? Identificacion { get; set; }

    public string? Tipo { get; set; }

    public string? DireccionProveedor { get; set; }

    public string? TelefonoProveedor { get; set; }

    public string? CorreoProveedor { get; set; }

    public virtual ICollection<FacturasCompra> FacturasCompras { get; set; } = new List<FacturasCompra>();
}
