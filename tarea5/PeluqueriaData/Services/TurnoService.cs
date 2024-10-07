using PeluqueriaData.Models;
using PeluqueriaData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaData.Services
{
    public class TurnoService : ITurnoService
    {
        private readonly ITurnoRepository _repository;
        public TurnoService( ITurnoRepository repository)
        {
            _repository = repository;
        }
        async public Task<bool> AgregarTurno(TTurno turno)
        {
            return await _repository.Create(turno);
        }

        public Task<bool> CancelarTurno(int id, string motivo)
        {
            return _repository.Delete(id, motivo);
        }

        public Task<bool> EditarTurno(TTurno turno)
        {
            return _repository.Update(turno);
        }

        async public Task<List<TTurno>> RecuperarTurnos()
        {
            return await _repository.GetAll();
        }

        public Task<List<TTurno>> RecuperarTurnosPorCliente(string cliente)
        {
            
            return _repository.GetAll(f => f.Cliente.Contains(cliente));
        }

        public Task<List<TTurno>> RecuperarTurnosPorFecha(DateTime fecha)
        {
            return _repository.GetAll(f => f.Fecha.Date == fecha.Date);
        }
    }
}
