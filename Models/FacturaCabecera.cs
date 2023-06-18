using System;
using System.Collections.Generic;

namespace Modelo_basado_en_BD_existente.Models;

public partial class FacturaCabecera
{
    public int IdfacturaCabecera { get; set; }

    public DateTime FechaRegistro { get; set; }

    public double Total { get; set; }

    public byte Estado { get; set; }

    public int ClienteIdcliente { get; set; }

    public int MetodoPagoIdmetodoPago { get; set; }

    public int FacturaDetalleIdfacturaDetalle { get; set; }

    public virtual Cliente ClienteIdclienteNavigation { get; set; } = null!;

    public virtual FacturaDetalle FacturaDetalleIdfacturaDetalleNavigation { get; set; } = null!;

    public virtual MetodoPago MetodoPagoIdmetodoPagoNavigation { get; set; } = null!;
}
