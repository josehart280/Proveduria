using System;
using System.Collections.Generic;

namespace Proveduria;

public partial class DetallesFacturasVenta
{
    public int IdDetalleVenta { get; set; }

    public int? IdFacturaVenta { get; set; }

    public int? IdProducto { get; set; }

    public int? Cantidad { get; set; }

    public decimal? PrecioUnitario { get; set; }

    public virtual FacturasVenta? IdFacturaVentaNavigation { get; set; }

    public virtual Productos? IdProductoNavigation { get; set; }
}
