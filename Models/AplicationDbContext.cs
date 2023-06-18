using Microsoft.EntityFrameworkCore;

namespace Modelo_basado_en_BD_existente.Models
{
    public class AplicationDbContext: DbContext 
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
            : base(options) 
        {
        }

    }
}
