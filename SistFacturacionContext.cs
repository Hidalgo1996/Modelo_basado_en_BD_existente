using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Modelo_basado_en_BD_existente;

public partial class SistFacturacionContext : DbContext
{
    public SistFacturacionContext()
    {
    }

    public SistFacturacionContext(DbContextOptions<SistFacturacionContext> options)
        : base(options)
    {
    }
}
