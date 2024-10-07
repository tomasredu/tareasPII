using PeluqueriaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaData.Services
{
    public interface ITurnoService
    {
        public Task<List<TTurno>> RecuperarTurnos();
        public Task<List<TTurno>> RecuperarTurnosPorFecha(DateTime fecha);
        public Task<List<TTurno>> RecuperarTurnosPorCliente(string cliente);
        public Task<bool> AgregarTurno(TTurno turno);
        public Task<bool> EditarTurno(TTurno turno);
        public Task<bool> CancelarTurno(int id, string motivo);
        
    }
}
