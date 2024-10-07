using PeluqueriaData.Models;
using PeluqueriaData.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluqueriaData.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _repository;
        public ServicioService(IServicioRepository repository)
        {
            _repository = repository;
        }

        async public Task<bool> Agregar(TServicio servicio)
        {
            return await _repository.Create(servicio);
        }

        async public Task<bool> Cancelar(int id, string motivo)
        {
            return await _repository.Delete(id, motivo);
        }

        async public Task<List<TServicio>> GetServicios()
        {
            return await _repository.GetAll();
        }

        async public Task<List<TServicio>> GetServiciosBaja(int dias)
        {
            return await _repository.GetByFilter(p => p.FechaBaja != null && (DateTime.Now - p.FechaBaja).Value.Days <= dias);
        }

        async public Task<List<TServicio>> GetServiciosCosto(int costo)
        {
            return await _repository.GetByFilter(p => p.Costo <= costo);
        }

        async public Task<List<TServicio>> GetServiciosNombre(string nombre)
        {
            return await _repository.GetByFilter(p => p.Nombre.Contains(nombre));
        }

        async public Task<bool> Modificar(TServicio servicio)
        {
            return await _repository.Update(servicio);
        }

        async public Task<TServicio?> GetServicio(int id)
        {
            return await _repository.GetById(id);
        }
    }
}
