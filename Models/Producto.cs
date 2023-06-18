using System;
using System.Collections.Generic;

namespace Modelo_basado_en_BD_existente.Models;

public partial class Producto
{
    public int Idproducto { get; set; }

    public string Nombre { get; set; } = null!;

    public double Precio { get; set; }

    public DateTime FechaRegistro { get; set; }

    public byte Estado { get; set; }

    public int CategoriaIdcategoria { get; set; }

    public virtual Categorium CategoriaIdcategoriaNavigation { get; set; } = null!;

    public virtual ICollection<FacturaDetalle> FacturaDetalles { get; set; } = new List<FacturaDetalle>();
}
