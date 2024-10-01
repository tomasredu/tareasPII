using Data.Domain;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Services.Interfaces
{
    public interface IServicioService
    {
        Task<bool> Cancelar(int id, string motivo);
        Task<bool> Agregar(Servicio servicio);
        Task<List<Servicio>> GetServicios();
        Task<List<Servicio>> GetServiciosCosto(int costo);
        Task<List<Servicio>> GetServiciosNombre(string nombre);
        Task<List<Servicio>> GetServiciosBaja(int dias);
        Task<Servicio?> GetServicio(int id);

        Task<bool> Modificar(Servicio servicio);

    }
}
