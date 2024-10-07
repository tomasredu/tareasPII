using PeluqueriaData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaData.Repositories
{
    public class ServicioRepository : IServicioRepository
    {
        private readonly PeluqueriaDbContext _context;
        public ServicioRepository(PeluqueriaDbContext context)
        {
            _context = context;
        }
        async public Task<bool> Create(TServicio servicio)
        {
            _context.TServicios.Add(servicio);
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        async public Task<bool> Delete(int id, string motivo)
        {
            var deleted = await _context.TServicios.FindAsync(id);
            if (deleted != null && deleted.FechaBaja == null)
            {
                deleted.FechaBaja = DateTime.Now;
                deleted.MotivoBaja = motivo;

            }
            var filas = await _context.SaveChangesAsync();
            return filas > 0;
        }

        async public Task<List<TServicio>> GetAll()
        {
            return await _context.TServicios.ToListAsync();
        }

        async public Task<List<TServicio>> GetByFilter(Func<TServicio, bool> filtro)
        {
            var lst = await _context.TServicios.ToListAsync();
            return lst.Where(filtro).ToList();
        }

        async public Task<TServicio?> GetById(int id)
        {
            return await _context.TServicios.FindAsync(id);
        }

        async public Task<bool> Update(TServicio servicio)
        {
            var updated = await _context.TServicios.FindAsync(servicio.IdServicio);
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
