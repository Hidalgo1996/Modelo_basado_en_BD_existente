using System;
using System.Collections.Generic;

namespace Modelo_basado_en_BD_existente.Models;

public partial class FacturaDetalle
{
    public int IdfacturaDetalle { get; set; }

    public double Cantidad { get; set; }

    public double Precio { get; set; }

    public int ProductoIdproducto { get; set; }

    public virtual ICollection<FacturaCabecera> FacturaCabeceras { get; set; } = new List<FacturaCabecera>();

    public virtual Producto ProductoIdproductoNavigation { get; set; } = null!;
}
