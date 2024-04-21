using System;
using System.Collections.Generic;

namespace Proveduria;

public partial class Productos
{
    public int IdProducto { get; set; }

    public string? NombreProducto { get; set; }

    public int? CantidadDisponible { get; set; }

    public decimal? PrecioVenta { get; set; }

    public virtual ICollection<DetallesFacturasCompra> DetallesFacturasCompras { get; set; } = new List<DetallesFacturasCompra>();

    public virtual ICollection<DetallesFacturasVenta> DetallesFacturasVenta { get; set; } = new List<DetallesFacturasVenta>();
}
