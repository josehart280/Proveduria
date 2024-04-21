using System;
using System.Collections.Generic;

namespace Proveduria;

public partial class FacturasCompra
{
    public int IdFacturaCompra { get; set; }

    public int? IdProveedor { get; set; }

    public DateOnly? FechaFactura { get; set; }

    public string? NumeroFactura { get; set; }

    public decimal? Impuesto { get; set; }

    public decimal? MontoTotal { get; set; }

    public decimal? TotalImpuestosPagados { get; set; }

    public virtual ICollection<DetallesFacturasCompra> DetallesFacturasCompras { get; set; } = new List<DetallesFacturasCompra>();

    public virtual Proveedores? IdProveedorNavigation { get; set; }
}
