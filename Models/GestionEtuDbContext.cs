using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace firstPrjAspCore.Models
{
    public class GestionEtuDbContext : DbContext
    {
        public GestionEtuDbContext(DbContextOptions<GestionEtuDbContext> option) : base(option)
        {

        }

        public DbSet<Etudiant> Etudiants { get; set;}
    }
}
