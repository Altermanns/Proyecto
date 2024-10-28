using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proyecto.Models;

namespace Proyecto.Data
{
    public class ProyectoContext : DbContext
    {
        public ProyectoContext (DbContextOptions<ProyectoContext> options)
            : base(options)
        {
        }

        public DbSet<Proyecto.Models.Usuario> Usuario { get; set; } = default!;
        public DbSet<Proyecto.Models.Vehiculo> Vehiculo { get; set; } = default!;
        public DbSet<Proyecto.Models.Transaccion> Transaccion { get; set; } = default!;
    }
}
