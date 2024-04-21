using System;
using System.Collections.Generic;

namespace Proveduria;

public partial class FacturasVenta
{
    public int IdFacturaVenta { get; set; }

    public int? IdCliente { get; set; }

    public DateOnly? FechaFactura { get; set; }

    public string? NumeroFactura { get; set; }

    public decimal? Impuesto { get; set; }

    public decimal? MontoTotal { get; set; }

    public decimal? TotalImpuestosCobrados { get; set; }

    public virtual ICollection<DetallesFacturasVenta> DetallesFacturasVenta { get; set; } = new List<DetallesFacturasVenta>();

    public virtual Cliente? IdClienteNavigation { get; set; }
}
