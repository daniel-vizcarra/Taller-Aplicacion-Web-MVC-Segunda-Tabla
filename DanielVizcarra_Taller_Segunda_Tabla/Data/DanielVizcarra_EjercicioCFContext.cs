using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DanielVizcarra_EjercicioCF.Models;

namespace DanielVizcarra_EjercicioCF.Data
{
    public class DanielVizcarra_EjercicioCFContext : DbContext
    {
        public DanielVizcarra_EjercicioCFContext (DbContextOptions<DanielVizcarra_EjercicioCFContext> options)
            : base(options)
        {
        }

        public DbSet<DanielVizcarra_EjercicioCF.Models.BurgerDV> BurgerDV { get; set; } = default!;
    }
}
