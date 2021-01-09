using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Beci_Helga_Proiect.Models;

namespace Beci_Helga_Proiect.Data
{
    public class Beci_Helga_ProiectContext : DbContext
    {
        public Beci_Helga_ProiectContext (DbContextOptions<Beci_Helga_ProiectContext> options)
            : base(options)
        {
        }

        public DbSet<Beci_Helga_Proiect.Models.Car> Car { get; set; }

        public DbSet<Beci_Helga_Proiect.Models.Seller> Seller { get; set; }

        public DbSet<Beci_Helga_Proiect.Models.Category> Category { get; set; }

        public DbSet<Beci_Helga_Proiect.Models.CarCategory> CarCategory { get; set; }
    }
}
