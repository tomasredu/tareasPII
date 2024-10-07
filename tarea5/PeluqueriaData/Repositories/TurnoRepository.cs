using Microsoft.EntityFrameworkCore;
using PeluqueriaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaData.Repositories
{
    public class TurnoRepository : ITurnoRepository
    {
        private readonly PeluqueriaDbContext _context;
        public TurnoRepository(PeluqueriaDbContext context)
        {
            _context = context;
        }
        async public Task<bool> Create(TTurno turno)
        {
            var ocupado = await _context.TTurnos.FirstOrDefaultAsync(t => t.Fecha.DayOfYear == turno.Fecha.DayOfYear 
                                                                       && t.Fecha.Hour == turno.Fecha.Hour);
            if(ocupado == null)
            {
                _context.TTurnos.Add(turno);
                /*
                foreach(TDetalleTurno det in turno.TDetallesTurnos)
                {
                    det.IdTurno = turno.IdTurno;
                    _context.TDetallesTurnos.Add(det);
                }
                */
                
            }
            
            return await _context.SaveChangesAsync() > 0;
        }

        async public Task<bool> Delete(int id, string motivo)
        {
            var toUpdate = _context.TTurnos.Find(id);
            if(toUpdate != null)
            {
                toUpdate.FechaBaja = DateTime.Now;
                toUpdate.MotivoBaja = motivo;
                
            }
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<List<TTurno>> GetAll()
        {
            return await _context.TTurnos.Include(t => t.TDetallesTurnos).ThenInclude(dt => dt.IdServicioNavigation).ToListAsync();
        }

        async public Task<List<TTurno>> GetAll(Expression<Func<TTurno, bool>> filter)
        {
            return await _context.TTurnos.Include(t => t.TDetallesTurnos).ThenInclude(dt => dt.IdServicioNavigation).Where(filter).ToListAsync();
        }

        async public Task<bool> Update(TTurno turno)
        {
            var toUpdate = _context.TTurnos.Find(turno.IdTurno);
            var ocupado = await _context.TTurnos.FirstOrDefaultAsync(t => t.Fecha.DayOfYear == turno.Fecha.DayOfYear
                                                                       && t.Fecha.Hour == turno.Fecha.Hour);
            if (toUpdate != null
                && (ocupado == null || toUpdate.IdTurno == ocupado.IdTurno))
            {
                toUpdate.Fecha = turno.Fecha;
                toUpdate.Cliente = turno.Cliente;
                toUpdate.FechaBaja =turno.FechaBaja;
                toUpdate.MotivoBaja = turno.MotivoBaja;
                /*
                _context.TDetallesTurnos.Where(d => d.IdTurno == turno.IdTurno).ExecuteDelete();
                foreach(var d in turno.TDetallesTurnos)
                {
                    _context.TDetallesTurnos.Add(d);
                }
                */
                toUpdate.TDetallesTurnos = turno.TDetallesTurnos;

            }
            return await _context.SaveChangesAsync() > 0;
        }
    }
}
