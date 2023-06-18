using System;
using System.Collections.Generic;

namespace Modelo_basado_en_BD_existente.Models;

public partial class Categorium
{
    public int Idcategoria { get; set; }

    public string NombreCategoria { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public byte Estado { get; set; }

    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
