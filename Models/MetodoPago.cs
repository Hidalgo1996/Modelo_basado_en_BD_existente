using System;
using System.Collections.Generic;

namespace Modelo_basado_en_BD_existente.Models;

public partial class MetodoPago
{
    public int IdmetodoPago { get; set; }

    public string NombrePago { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public byte Estado { get; set; }

    public virtual ICollection<FacturaCabecera> FacturaCabeceras { get; set; } = new List<FacturaCabecera>();
}
