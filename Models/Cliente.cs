using System;
using System.Collections.Generic;

namespace Modelo_basado_en_BD_existente.Models;

public partial class Cliente
{
    public int Idcliente { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public DateTime FechaNacimiento { get; set; }

    public DateTime FechaRegistro { get; set; }

    public byte Estado { get; set; }

    public virtual ICollection<FacturaCabecera> FacturaCabeceras { get; set; } = new List<FacturaCabecera>();
}
