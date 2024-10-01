using Data.Domain;
using Data.Models;
using Data.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly TurnosDbContext _context;
        public ServicioRepository(TurnosDbContext context)
        {
            _context = context;
        }
        async public Task<bool> Create(Servicio servicio)
        {
            _context.Servicios.Add(servicio);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        async public Task<bool> Delete(int id, string motivo)
        {
            var deleted = await _context.Servicios.FindAsync(id);
            if(deleted != null && deleted.FechaBaja == null)
            {
                deleted.FechaBaja = DateTime.Now;
                deleted.MotivoBaja = motivo;

            }
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        async public Task<List<Servicio>> GetAll()
        {
            return await _context.Servicios.ToListAsync();
        }

        async public Task<List<Servicio>> GetByFilter(Func<Servicio, bool> filtro)
        {
            var lst = await _context.Servicios.ToListAsync();
            return lst.Where(filtro).ToList();
        }

        async public Task<Servicio?> GetById(int id)
        {
            return await _context.Servicios.FindAsync(id);
        }

        async public Task<bool> Update(Servicio servicio)
        {
            var updated = await _context.Servicios.FindAsync(servicio.Id);
            if (updated != null)
            {
                updated.Nombre = servicio.Nombre;
                updated.Costo = servicio.Costo;
                updated.EnPromocion = servicio.EnPromocion;
                updated.FechaBaja = servicio.FechaBaja;
                updated.MotivoBaja = servicio.MotivoBaja;

                _context.Update(updated);

            }
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }
    }
}
