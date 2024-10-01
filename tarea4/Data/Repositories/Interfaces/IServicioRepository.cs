using Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories.Interfaces
{
    public interface IServicioRepository
    {
        Task<List<Servicio>> GetAll();
        Task<List<Servicio>> GetByFilter(Func<Servicio,bool> filtro);
        Task<Servicio?> GetById(int id);
        Task<bool> Delete(int id, string motivo);
        Task<bool> Create(Servicio servicio);
        Task<bool> Update(Servicio servicio);
    }
}
