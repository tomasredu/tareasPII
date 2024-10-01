using Data.Domain;
using Data.Models.Configurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Models
{
    public class TurnosDbContext : DbContext
    {
        
        
        public TurnosDbContext( DbContextOptions options) : base (options)
        { 
            
        }
        

        

        public DbSet<Servicio> Servicios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new ServicioConfiguration().Configure(modelBuilder.Entity<Servicio>());
        }

        
    }
}
