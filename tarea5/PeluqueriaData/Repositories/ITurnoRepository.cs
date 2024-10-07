using PeluqueriaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaData.Repositories
{
    public interface ITurnoRepository
    {
        Task<List<TTurno>> GetAll();
        Task<List<TTurno>> GetAll(Expression<Func<TTurno,bool>> filter);
        Task<bool> Create(TTurno turno);
        Task<bool> Update(TTurno turno);
        Task<bool> Delete(int id, string motivo);
    }
}
