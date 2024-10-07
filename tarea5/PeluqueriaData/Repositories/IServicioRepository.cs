using PeluqueriaData.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaData.Repositories
{
    public interface IServicioRepository
    {
        Task<List<TServicio>> GetAll();
        Task<List<TServicio>> GetByFilter(Func<TServicio, bool> filtro);
        Task<TServicio?> GetById(int id);
        Task<bool> Delete(int id, string motivo);
        Task<bool> Create(TServicio servicio);
        Task<bool> Update(TServicio servicio);
    }
}
