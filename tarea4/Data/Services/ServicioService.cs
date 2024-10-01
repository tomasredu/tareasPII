using Data.Domain;
using Data.Repositories;
using Data.Repositories.Interfaces;
using Data.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Data.Services
{
    public class ServicioService : IServicioService
    {
        private readonly IServicioRepository _repository;
        public ServicioService(IServicioRepository repository)
        {
            _repository = repository;
        }

        async public Task<bool> Agregar(Servicio servicio)
        {
            return await _repository.Create(servicio);
        }

        async public Task<bool> Cancelar(int id, string motivo)
        {
            return await _repository.Delete(id, motivo);
        }

        async public Task<List<Servicio>> GetServicios()
        {
            return await _repository.GetAll();
        }

        async public Task<List<Servicio>> GetServiciosBaja(int dias)
        {
            return await _repository.GetByFilter(p => p.FechaBaja != null && (DateTime.Now - p.FechaBaja).Value.Days <= dias);
        }

        async public Task<List<Servicio>> GetServiciosCosto(int costo)
        {
            return await _repository.GetByFilter(p => p.Costo <= costo);
        }

        async public Task<List<Servicio>> GetServiciosNombre(string nombre)
        {
            return await _repository.GetByFilter(p => p.Nombre.Contains(nombre));
        }

        async public Task<bool> Modificar(Servicio servicio)
        {
            return await _repository.Update(servicio);
        }

        async public Task<Servicio?> GetServicio(int id)
        {
            return await _repository.GetById(id);
        }
    }
}
